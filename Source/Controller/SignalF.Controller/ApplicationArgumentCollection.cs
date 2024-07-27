using System.Collections.ObjectModel;
using SignalF.Controller.Configuration;

namespace SignalF.Controller;

public class ApplicationArgumentCollection : ReadOnlyCollection<string>, IApplicationArgumentCollection
{
    public ApplicationArgumentCollection() : base(Environment.GetCommandLineArgs().ToList())
    {
    }
}
