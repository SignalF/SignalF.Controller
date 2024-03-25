using Microsoft.Extensions.Logging;
using SignalF.Controller.Signals.SignalProcessor;
using SignalF.Datamodel.Calculation;

namespace SignalF.Controller.Signals.Calculators;

public abstract class Calculator<TConfiguration> : SignalProcessor<TConfiguration>, ICalculator
    where TConfiguration : ICalculatorConfiguration
{
    protected Calculator(ISignalHub signalHub, ILogger<Calculator<TConfiguration>> logger)
        : base(signalHub, logger)
    {
    }
}
