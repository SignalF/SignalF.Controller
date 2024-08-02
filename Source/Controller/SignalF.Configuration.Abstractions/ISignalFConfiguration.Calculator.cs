using SignalF.Configuration.Calculators;
using SignalF.Controller;
using SignalF.Controller.Configuration;
using SignalF.Controller.Signals.Calculators;
using SignalF.Datamodel.Calculation;

namespace SignalF.Configuration;

public partial interface ISignalFConfiguration
{
    ISignalFConfiguration AddCalculatorConfiguration<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : ICalculatorConfigurationBuilder<TBuilder, ICalculatorConfiguration, TOptions>
        where TOptions : CalculatorOptions;

    ISignalFConfiguration AddCalculatorConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : ICalculatorConfigurationBuilder<TBuilder, ICalculatorConfiguration, TOptions>
        where TOptions : CalculatorOptions
        where TType : class, ICalculator;

    ISignalFConfiguration AddCalculatorDefinition<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : ICalculatorDefinitionBuilder<TBuilder, ICalculatorDefinition, TOptions>
        where TOptions : CalculatorOptions;

    ISignalFConfiguration AddCalculatorDefinition<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : ICalculatorDefinitionBuilder<TBuilder, ICalculatorDefinition, TOptions>
        where TOptions : CalculatorOptions
        where TType : class, ICalculator;

    ISignalFConfiguration AddCalculatorTemplate<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : ICalculatorTemplateBuilder<TBuilder, ICalculatorTemplate, TOptions>
        where TOptions : CalculatorOptions;

    ISignalFConfiguration AddCalculatorTemplate<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : ICalculatorTemplateBuilder<TBuilder, ICalculatorTemplate, TOptions>
        where TOptions : CalculatorOptions
        where TType : class, ICalculator;
}
