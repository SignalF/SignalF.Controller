using System.Runtime.Loader;

namespace SignalF.Controller.Signals.ProcessControl;

// used to access protected constructor
public class CollectibleAssemblyLoadContext : AssemblyLoadContext
{
    public CollectibleAssemblyLoadContext() : base(true)
    {
    }
}
