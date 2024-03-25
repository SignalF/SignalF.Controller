#region

using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using SignalF.Controller.Hardware.Channels;
using SignalF.Controller.Signals.Calculator;
using SignalF.Controller.Signals.SignalProcessor;
using SignalF.Datamodel.Hardware;

#endregion

namespace SignalF.Controller.Signals.Calculators;

public abstract class Calculator<TConfiguration> : SignalProcessor<TConfiguration>, ICalculator
    where TConfiguration : IDeviceConfiguration
{
    protected Calculator(ISignalHub signalHub, ILogger<Calculator<TConfiguration>> logger)
        : base(signalHub, logger)
    {
    }
}
