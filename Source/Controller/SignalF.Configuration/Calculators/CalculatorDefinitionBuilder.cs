using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Calculation;

namespace SignalF.Configuration.Calculators;

public class CalculatorDefinitionBuilder
    : CalculatorDefinitionBuilder<CalculatorDefinitionBuilder, ICalculatorDefinitionBuilder, ICalculatorDefinition, SignalFConfigurationOptions>,
      ICalculatorDefinitionBuilder
{
    protected override ICalculatorDefinitionBuilder This => this;
}

public abstract class CalculatorDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : SignalProcessorDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>, ICalculatorDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : ICalculatorDefinitionBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : CalculatorDefinitionBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : ICalculatorDefinition
    where TOptions : SignalFConfigurationOptions
{
}
