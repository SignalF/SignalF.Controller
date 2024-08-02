using SignalF.Configuration.SignalConfiguration;
using SignalF.Datamodel.Calculation;

namespace SignalF.Configuration.Calculators;

public interface ICalculatorTemplateBuilder : ICalculatorTemplateBuilder<ICalculatorTemplateBuilder, ICalculatorTemplate, CalculatorOptions>
{
}

public interface ICalculatorTemplateBuilder<out TBuilder, in TConfiguration, in TOptions> : ISignalProcessorTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : ICalculatorTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : ICalculatorTemplate
    where TOptions : CalculatorOptions
{
}
