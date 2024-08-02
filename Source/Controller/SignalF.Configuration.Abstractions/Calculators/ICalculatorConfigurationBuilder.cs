using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Calculation;

namespace SignalF.Configuration.Calculators;

public interface
    ICalculatorConfigurationBuilder : ICalculatorConfigurationBuilder<ICalculatorConfigurationBuilder, ICalculatorConfiguration, ICalculatorConfiguration>
{
}

public interface
    ICalculatorConfigurationBuilder<out TBuilder, in TConfiguration, in TOptions> 
    : ISignalProcessorConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : ICalculatorConfigurationBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : ICalculatorConfiguration
    where TOptions : CalculatorOptions
{
}
