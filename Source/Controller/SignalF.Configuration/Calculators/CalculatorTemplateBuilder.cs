using SignalF.Configuration.SignalConfiguration;
using SignalF.Datamodel.Calculation;

namespace SignalF.Configuration.Calculators;

public class CalculatorTemplateBuilder
    : CalculatorTemplateBuilder<CalculatorTemplateBuilder, ICalculatorTemplateBuilder, ICalculatorTemplate, CalculatorOptions>,
      ICalculatorTemplateBuilder
{
    protected override ICalculatorTemplateBuilder This => this;
}

public abstract class CalculatorTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    : SignalProcessorTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>, ICalculatorTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : ICalculatorTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TImpl : CalculatorTemplateBuilder<TImpl, TBuilder, TConfiguration, TOptions>
    where TConfiguration : ICalculatorTemplate
    where TOptions : CalculatorOptions
{
}
