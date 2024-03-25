using SignalF.Configuration.SignalConfiguration;
using SignalF.Controller.Configuration;
using SignalF.Datamodel.Calculation;

namespace SignalF.Configuration.Calculators;

public interface ICalculatorTemplateBuilder : ICalculatorTemplateBuilder<ICalculatorTemplateBuilder, ICalculatorTemplate, SignalFConfigurationOptions>
{
}

public interface ICalculatorTemplateBuilder<out TBuilder, in TConfiguration, in TOptions> : ISignalProcessorTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TBuilder : ICalculatorTemplateBuilder<TBuilder, TConfiguration, TOptions>
    where TConfiguration : ICalculatorTemplate
    where TOptions : SignalFConfigurationOptions
{
}
