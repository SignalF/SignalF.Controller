using System.Collections.Generic;

namespace SignalF.Controller.Configuration;

public interface IApplicationArgumentCollection : IReadOnlyCollection<string>, IList<string>
{
}
