using SignalF.Configuration;
using SignalF.Controller.Hardware.Channels;
using SignalF.Controller.Signals.Devices;
using SignalF.Datamodel.Configuration;
using SignalF.Datamodel.Signals;

//namespace GeneratorTest
namespace SignalF.Extensions.IotDevices.Class1
{
    [Device]
    public class Class1 : IDevice
    {
        public Guid Id { get; }
        public string Name { get; }
        public void Configure(ISignalProcessorConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        public void Execute(ETaskType taskType)
        {
            throw new NotImplementedException();
        }

        public void AssignChannels(IList<IChannel> channels)
        {
            throw new NotImplementedException();
        }
    }

    public class Test
    {
        private Class1 x;
    }
}
