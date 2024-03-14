#region

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Threading;
using Microsoft.Extensions.Logging;

#endregion

namespace SignalF.Controller.Timer;

public delegate void ElapsedEventHandler(object sender, ScotecTimerEventArgs eventArgs);

[SupportedOSPlatform("linux")]
[SupportedOSPlatform("windows")]
public class ScotecTimer
{
    private readonly ITimestampProvider _timestampProvider;

    //public static int GetNativeThreadId(Thread thread)
    //{
    //    var f = typeof(Thread).GetField("DONT_USE_InternalThread",
    //        BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);

    //    var pInternalThread = (IntPtr)f.GetValue(thread);
    //    var nativeId = Marshal.ReadInt32(pInternalThread, (IntPtr.Size == 8) ? 548 : 348); // found by analyzing the memory
    //    return nativeId;
    //}

    private long _ignoreCutoff = long.MaxValue;

    private long _interval;
    private bool _timerRunning;
    private Thread _timerThread;

    public ScotecTimer(ITimestampProvider timestampProvider)
    {
        _timestampProvider = timestampProvider;
    }

    public ScotecTimer(ITimestampProvider timestampProvider, ILogger<ScotecTimer> logger)
    {
        Logger = logger;
        _timestampProvider = timestampProvider;
    }

    public ILogger<ScotecTimer> Logger { get; }

    // TODO: Get affinity from configuration.
    public uint ProcessorAffinity { get; set; } = 0x01;

    /// <summary>
    ///     Gets or sets the interval, expressed in microseconds, at which to raise the Elapsed event.
    /// </summary>
    public long Interval
    {
        get => Interlocked.Read(ref _interval);
        set => Interlocked.Exchange(ref _interval, value);
    }

    /// <summary>
    ///     Gets or sets the cutoff, in microseconds, after which an event is ignored if it is late.
    ///     If set to 0, no events will be skipped and the timer tries to catch up.
    /// </summary>
    public long IgnoreCutoff
    {
        get => Interlocked.Read(ref _ignoreCutoff);
        set => Interlocked.Exchange(ref _ignoreCutoff, value <= 0 ? long.MaxValue : value);
    }

    /// <summary>
    ///     Gets or sets the value whether the ScotecTimer should raise the Elapsed event.
    /// </summary>
    public bool Enabled
    {
        get => _timerThread != null && _timerThread.IsAlive;
        set
        {
            if (value)
            {
                Start();
            }
            else
            {
                Stop();
            }
        }
    }

    public int StartDelay { get; set; } = 10_000_000; //SpinWaits

    /// <summary>
    ///     Occurs when the interval elapses.
    /// </summary>
    public event ElapsedEventHandler Elapsed;

    /// <summary>
    ///     Starts raising the elapsed event.
    /// </summary>
    public void Start()
    {
        if (Enabled || Interval <= 0)
        {
            return;
        }

        _timerRunning = true;
        _timerThread = new Thread(RunTimer)
        {
            Priority = ThreadPriority.Highest, Name = "Scotec.Timer", IsBackground = true
        };
        _timerThread.Start();
    }

    /// <summary>
    ///     Stops raising the elapsed event.
    /// </summary>
    public void Stop()
    {
        _timerRunning = false;
    }

    /// <summary>
    ///     Stops raising the elapsed event and waits until the timer thread is shut down.
    /// </summary>
    public void StopAndWait()
    {
        StopAndWait(Timeout.Infinite);
    }

    /// <summary>
    ///     Stops raising the elapsed event and waits for given timeout that the timer thread is shut down.
    /// </summary>
    /// <param name="timeoutInMilliseconds">Timeout to wait for, in milliseconds</param>
    /// <returns>true if the timer thread was successfully shut down, false otherwise</returns>
    public bool StopAndWait(int timeoutInMilliseconds)
    {
        _timerRunning = false;

        if (!Enabled || _timerThread!.ManagedThreadId == Thread.CurrentThread.ManagedThreadId)
        {
            return true;
        }

        return _timerThread.Join(timeoutInMilliseconds);
    }

    private void RunTimer()
    {
        Thread.BeginThreadAffinity();
        try
        {
            SetPriority();

            Thread.SpinWait(StartDelay);

            _timestampProvider.Start();
            var counter = 0;
            var startTime = _timestampProvider.Timestamp;
            var lastTime = startTime;
            var nextAction = lastTime;

            long executionTime = 0;
            while (_timerRunning)
            {
                var currentInterval = Interlocked.Read(ref _interval) * 10;
                var currentIgnoreCutoff = Interlocked.Read(ref _ignoreCutoff);

                nextAction += currentInterval;
                ++counter;

                long elapsed;
                while ((elapsed = _timestampProvider.Timestamp) < nextAction)
                {
                    //Thread.SpinWait(10);
                }

                var offset = elapsed - nextAction;
                if (offset >= currentIgnoreCutoff)
                {
                    continue;
                }

                var eventArgs = new ScotecTimerEventArgs
                {
                    Timestamp = elapsed, ExecutionTime = executionTime, Counter = counter, Elapsed = elapsed - startTime, Offset = offset, LastTime = lastTime
                };

                Elapsed?.Invoke(this, eventArgs);

                lastTime = elapsed;
                executionTime = _timestampProvider.Timestamp - elapsed;
            }
        }
        finally
        {
            Thread.EndThreadAffinity();
        }

        _timestampProvider.Stop();
    }

    private void SetPriority()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            SetPriorityWin();
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            SetPriorityLinux();
        }
    }

    /// <summary>
    ///     Sets the CPU affinity mask of the thread thread to the CPU set pointed to by cpuset.
    ///     This funktion is not supported on all Linux distributions.
    /// </summary>
    [DllImport("libc.so.6", EntryPoint = "pthread_setaffinity_np")]
    private static extern int SetLinuxThreadAffinity(ulong threadId, ulong cpuSetSize, IntPtr cpuSet);

    [DllImport("Kernel32", EntryPoint = "GetCurrentThreadId", ExactSpelling = true)]
    public static extern int GetCurrentWin32ThreadId();

    [DllImport("libc.so.6", EntryPoint = "pthread_self")]
    private static extern ulong Self();

    [DllImport("libc.so.6", EntryPoint = "sched_get_priority_max")]
    private static extern int GetMaxPriority(int policy);

    [DllImport("libc.so.6", EntryPoint = "pthread_getschedparam")]
    private static extern int GetSchedParam(ulong threadId, ref int policy, ref int param);

    [DllImport("libc.so.6", EntryPoint = "pthread_setschedparam")]
    private static extern int SetSchedParam(ulong threadId, int policy, ref int param);

    [SupportedOSPlatform("linux")]
    private void SetPriorityLinux()
    {
        ulong cpuMask = ProcessorAffinity;
        var cpuMaskPtr = (IntPtr)0;

        try
        {
            var threadId = Self();

            // Get the max. thread priority. 
            var policy = (int)SchedulerPolicy.SCHED_FIFO;
            var maxPriority = GetMaxPriority(policy);

            // Set the priority of the current thread to max. priority.
            var result = SetSchedParam(threadId, policy, ref maxPriority);
            if (result != 0)
            {
                Logger?.LogError($"Failed to set thread priority. Error code: {result}");
                //Console.WriteLine($"Failed to set thread priority. Error code: {result}");
            }

            //var paramPtr = Marshal.AllocHGlobal(Marshal.SizeOf(priority));
            //Marshal.StructureToPtr(priority, paramPtr, false);
            //var result = GetSchedParam(threadId, ref policy, ref priority);
            //priority = Marshal.PtrToStructure<int>(paramPtr);

#if USE_AFFINITY
            // Set the CPU affinity for the current thread.
            // This function is not supported on all Linux distributions.      
            cpuMaskPtr = Marshal.AllocHGlobal(Marshal.SizeOf(cpuMask));
            Marshal.StructureToPtr(cpuMask, cpuMaskPtr, false);
            result = SetLinuxThreadAffinity(threadId, (ulong)Marshal.SizeOf(cpuMask), cpuMaskPtr);

            if (result != 0)
            {
                Logger?.LogError($"Failed to set thread affinity. Error code: {result}");
                //Console.WriteLine($"Failed to set thread affinity. Error code: {result}");
            }
#endif
        }
        catch (EntryPointNotFoundException)
        {
            Logger?.LogError("Failed to set thread affinity: Function is not supported on current linux distribution.");
            //Console.WriteLine("Failed to set thread affinity: Function is not supported on current linux distribution.");
        }
        finally
        {
            Marshal.FreeHGlobal(cpuMaskPtr);
        }
    }

    [SupportedOSPlatform("windows")]
    private void SetPriorityWin()
    {
        var process = Process.GetCurrentProcess();
        var currentThreadId = GetCurrentWin32ThreadId();
        var thread = process.Threads.OfType<ProcessThread>()
                            .FirstOrDefault(t => t.Id == currentThreadId);

        if (thread != null)
        {
            thread.PriorityLevel = ThreadPriorityLevel.TimeCritical;
            thread.ProcessorAffinity = new IntPtr(ProcessorAffinity);
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    private enum SchedulerPolicy
    {
        SCHED_OTHER = 0,
        SCHED_FIFO = 1,
        SCHED_RR = 2,
        SCHED_BATCH = 3
    }
}
