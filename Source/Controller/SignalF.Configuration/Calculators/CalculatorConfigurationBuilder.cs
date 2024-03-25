using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Calculation;

namespace SignalF.Configuration.Calculators;

public class CalculatorConfigurationBuilder
    : CalculatorConfigurationBuilder<CalculatorConfigurationBuilder, ICalculatorConfigurationBuilder, ICalculatorConfiguration, SignalFConfigurationOptions>,
      ICalculatorConfigurationBuilder
{
    protected override ICalculatorConfigurationBuilder This => this;
}

public abstract class CalculatorConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : SignalProcessorConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>, ICalculatorConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : ICalculatorConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : CalculatorConfigurationBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : ICalculatorConfiguration
    where TOptions : SignalFConfigurationOptions
{
}
