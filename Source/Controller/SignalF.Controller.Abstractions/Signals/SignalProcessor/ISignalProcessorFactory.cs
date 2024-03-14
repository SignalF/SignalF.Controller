#region

using System;
using System.Collections.Generic;

#endregion

namespace SignalF.Controller.Signals.SignalProcessor;

public interface ISignalProcessorFactory
{
    ISignalProcessor GetSignalProcessor(Type type, Guid id);

    ISignalProcessor FindSignalProcessor(Guid id);

    /// <summary>
    ///     Returns all signal processor instances of the given type.
    /// </summary>
    /// <remarks>A call to GetSignalProcessors does not instantiate any new signal processor.</remarks>
    IEnumerable<TSignalProcessor> GetSignalProcessors<TSignalProcessor>()
        where TSignalProcessor : ISignalProcessor;
}
