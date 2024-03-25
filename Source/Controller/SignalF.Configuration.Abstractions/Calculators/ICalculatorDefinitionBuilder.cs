using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Calculation;

namespace SignalF.Configuration.Calculators;

public interface ICalculatorDefinitionBuilder : ICalculatorDefinitionBuilder<ICalculatorDefinitionBuilder, ICalculatorDefinition, SignalFConfigurationOptions>
{
}

public interface
    ICalculatorDefinitionBuilder<out TBuilder, in TConfiguration, in TOptions> : ISignalProcessorDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : ICalculatorDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : ICalculatorDefinition
    where TOptions : SignalFConfigurationOptions
{
}
