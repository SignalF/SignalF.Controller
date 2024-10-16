using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Configuration
{
	public partial interface IControllerConfiguration : IBusinessObject, Scotec.XMLDatabase.IVisitable
	{

		#region Properties

		SignalF.Datamodel.Hardware.IChannelToDevicesMappingList ChannelToDeviceMappings { get; }

		SignalF.Datamodel.Hardware.IChannelToSignalEndpointsMappingList ChannelToSignalEndpointsMappings { get; }

		SignalF.Datamodel.Signals.ISignalConnectionList Connections { get; }

		SignalF.Datamodel.DataOutput.IDataOutputConfigurationList DataOutputConfigurations { get; }

		SignalF.Datamodel.DataOutput.IDataOutputSenderConfigurationList DataOutputSenderConfigurations { get; }

		SignalF.Datamodel.Designer.IDesignerConfiguration DesignerConfiguration { get; }

		SignalF.Datamodel.Hardware.IDeviceBindingConfigurationList DeviceBindings { get; }

		SignalF.Datamodel.Hardware.IHardwareConfiguration HardwareConfiguration { get; }

		System.Guid Id { get; }

		SignalF.Datamodel.Signals.ISignalProcessorConfigurationList SignalProcessorConfigurations { get; }

		SignalF.Datamodel.Signals.ISignalProcessorDefinitionList SignalProcessorDefinitions { get; }

		SignalF.Datamodel.Signals.ISignalProcessorTemplateList SignalProcessorTemplates { get; }

		SignalF.Datamodel.Configuration.ITaskConfigurationList TaskConfigurations { get; }

		#endregion Properties


		#region Methods






		bool HasDesignerConfiguration();
		SignalF.Datamodel.Designer.IDesignerConfiguration CreateDesignerConfiguration();
		TDesignerConfiguration CreateDesignerConfiguration<TDesignerConfiguration>() where TDesignerConfiguration : SignalF.Datamodel.Designer.IDesignerConfiguration;
		void DeleteDesignerConfiguration();







		#endregion Methods

	}

	public interface IControllerConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IControllerConfiguration visitable);
	}
}

