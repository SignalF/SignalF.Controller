﻿using Microsoft.Extensions.DependencyInjection;
using SignalF.Configuration.Calculators;
using SignalF.Controller.Signals.Calculators;
using SignalF.Datamodel.Calculation;

namespace SignalF.Configuration;

public partial class SignalFConfiguration : ISignalFConfiguration
{
    public ISignalFConfiguration AddCalculatorConfiguration<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : ICalculatorConfigurationBuilder<TBuilder, ICalculatorConfiguration, TOptions>
        where TOptions : CalculatorOptions
    {
        _signalProcessorConfigurations.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorConfigurations.Create<ICalculatorConfiguration>());
        });
        return this;
    }

    public ISignalFConfiguration AddCalculatorConfiguration<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : ICalculatorConfigurationBuilder<TBuilder, ICalculatorConfiguration, TOptions>
        where TOptions : CalculatorOptions
        where TType : class, ICalculator
    {
        _signalProcessorConfigurations.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            builder.SetType<TType>();
            action(builder);
            builder.Build(configuration.SignalProcessorConfigurations.Create<ICalculatorConfiguration>());
        });
        return this;
    }

    public ISignalFConfiguration AddCalculatorDefinition<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : ICalculatorDefinitionBuilder<TBuilder, ICalculatorDefinition, TOptions>
        where TOptions : CalculatorOptions
    {
        _signalProcessorDefinitions.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorDefinitions.Create<ICalculatorDefinition>());
        });
        return this;
    }

    public ISignalFConfiguration AddCalculatorDefinition<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : ICalculatorDefinitionBuilder<TBuilder, ICalculatorDefinition, TOptions>
        where TOptions : CalculatorOptions
        where TType : class, ICalculator
    {
        _signalProcessorDefinitions.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            builder.SetType<TType>();
            action(builder);
            builder.Build(configuration.SignalProcessorDefinitions.Create<ICalculatorDefinition>());
        });
        return this;
    }

    public ISignalFConfiguration AddCalculatorTemplate<TBuilder, TOptions>(Action<TBuilder> action)
        where TBuilder : ICalculatorTemplateBuilder<TBuilder, ICalculatorTemplate, TOptions>
        where TOptions : CalculatorOptions
    {
        _signalProcessorTemplates.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            action(builder);
            builder.Build(configuration.SignalProcessorTemplates.Create<ICalculatorTemplate>());
        });
        return this;
    }

    public ISignalFConfiguration AddCalculatorTemplate<TBuilder, TOptions, TType>(Action<TBuilder> action)
        where TBuilder : ICalculatorTemplateBuilder<TBuilder, ICalculatorTemplate, TOptions>
        where TOptions : CalculatorOptions
        where TType : class, ICalculator
    {
        _signalProcessorTemplates.Add(configuration =>
        {
            var builder = _serviceProvider.GetRequiredService<TBuilder>();
            builder.SetType<TType>();
            action(builder);
            builder.Build(configuration.SignalProcessorTemplates.Create<ICalculatorTemplate>());
        });
        return this;
    }
}
