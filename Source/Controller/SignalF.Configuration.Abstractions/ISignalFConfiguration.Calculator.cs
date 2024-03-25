using System;
using SignalF.Configuration.Calculators;
using SignalF.Controller.Configuration;
using SignalF.Controller.Signals.Calculators;

namespace SignalF.Configuration;

public partial interface ISignalFConfiguration
{
    ISignalFConfiguration AddCalculatorConfiguration<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : ICalculatorConfigurationBuilder
        where TOptions : SignalFConfigurationOptions;

    ISignalFConfiguration AddCalculatorConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : ICalculatorConfigurationBuilder
        where TOptions : SignalFConfigurationOptions
        where TType : class, ICalculator;

    ISignalFConfiguration AddCalculatorDefinition<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : ICalculatorDefinitionBuilder
        where TOptions : SignalFConfigurationOptions;

    ISignalFConfiguration AddCalculatorDefinition<TBuilder, TOptions, TType>(Action<TBuilder> builder)
        where TBuilder : ICalculatorDefinitionBuilder
        where TOptions : SignalFConfigurationOptions
        where TType : class, ICalculator;

    ISignalFConfiguration AddCalculatorTemplate<TBuilder, TOptions>(Action<TBuilder> builder)
        where TBuilder : ICalculatorTemplateBuilder
        where TOptions : SignalFConfigurationOptions;

    ISignalFConfiguration AddCalculatorTemplate<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : ICalculatorTemplateBuilder
        where TOptions : SignalFConfigurationOptions
        where TType : class, ICalculator;
}
