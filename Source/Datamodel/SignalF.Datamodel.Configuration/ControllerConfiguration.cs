using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Configuration
{
	public partial class ControllerConfiguration : BusinessObject, SignalF.Datamodel.Configuration.IControllerConfiguration
	{
		#region Properties

		
		SignalF.Datamodel.Hardware.IChannelToDevicesMappingList IControllerConfiguration.ChannelToDeviceMappings
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Hardware.IChannelToDevicesMappingList)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("ChannelToDeviceMappings"));
				}
				catch(Scotec.XMLDatabase.DataException e)
				{
					throw new BusinessException((EBusinessError)e.DataError, e.Message, e);
				}
				catch(Exception e)
				{
					throw new BusinessException(EBusinessError.Document, "Caught unhandled exception.", e);
				}
			}
		}
		
		SignalF.Datamodel.Hardware.IChannelToSignalEndpointsMappingList IControllerConfiguration.ChannelToSignalEndpointsMappings
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Hardware.IChannelToSignalEndpointsMappingList)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("ChannelToSignalEndpointsMappings"));
				}
				catch(Scotec.XMLDatabase.DataException e)
				{
					throw new BusinessException((EBusinessError)e.DataError, e.Message, e);
				}
				catch(Exception e)
				{
					throw new BusinessException(EBusinessError.Document, "Caught unhandled exception.", e);
				}
			}
		}
		
		SignalF.Datamodel.Signals.ISignalConnectionList IControllerConfiguration.Connections
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Signals.ISignalConnectionList)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("Connections"));
				}
				catch(Scotec.XMLDatabase.DataException e)
				{
					throw new BusinessException((EBusinessError)e.DataError, e.Message, e);
				}
				catch(Exception e)
				{
					throw new BusinessException(EBusinessError.Document, "Caught unhandled exception.", e);
				}
			}
		}
		
		SignalF.Datamodel.DataOutput.IDataOutputConfigurationList IControllerConfiguration.DataOutputConfigurations
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.DataOutput.IDataOutputConfigurationList)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("DataOutputConfigurations"));
				}
				catch(Scotec.XMLDatabase.DataException e)
				{
					throw new BusinessException((EBusinessError)e.DataError, e.Message, e);
				}
				catch(Exception e)
				{
					throw new BusinessException(EBusinessError.Document, "Caught unhandled exception.", e);
				}
			}
		}
		
		SignalF.Datamodel.DataOutput.IDataOutputSenderConfigurationList IControllerConfiguration.DataOutputSenderConfigurations
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.DataOutput.IDataOutputSenderConfigurationList)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("DataOutputSenderConfigurations"));
				}
				catch(Scotec.XMLDatabase.DataException e)
				{
					throw new BusinessException((EBusinessError)e.DataError, e.Message, e);
				}
				catch(Exception e)
				{
					throw new BusinessException(EBusinessError.Document, "Caught unhandled exception.", e);
				}
			}
		}
		
		SignalF.Datamodel.Hardware.IDeviceBindingConfigurationList IControllerConfiguration.DeviceBindings
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Hardware.IDeviceBindingConfigurationList)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("DeviceBindings"));
				}
				catch(Scotec.XMLDatabase.DataException e)
				{
					throw new BusinessException((EBusinessError)e.DataError, e.Message, e);
				}
				catch(Exception e)
				{
					throw new BusinessException(EBusinessError.Document, "Caught unhandled exception.", e);
				}
			}
		}
		
		SignalF.Datamodel.Hardware.IHardwareConfiguration IControllerConfiguration.HardwareConfiguration
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Hardware.IHardwareConfiguration)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("HardwareConfiguration"));
				}
				catch(Scotec.XMLDatabase.DataException e)
				{
					throw new BusinessException((EBusinessError)e.DataError, e.Message, e);
				}
				catch(Exception e)
				{
					throw new BusinessException(EBusinessError.Document, "Caught unhandled exception.", e);
				}
			}
		}
		
		private const string ID_PROPERTY_NAME = "id";		
		System.Guid IControllerConfiguration.Id
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Base.IIdentifier)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(ID_PROPERTY_NAME))).Value;
				}
				catch(Scotec.XMLDatabase.DataException e)
				{
					throw new BusinessException((EBusinessError)e.DataError, e.Message, e);
				}
				catch(Exception e)
				{
					throw new BusinessException(EBusinessError.Document, "Caught unhandled exception.", e);
				}
			}
		}
		
		SignalF.Datamodel.Signals.ISignalProcessorConfigurationList IControllerConfiguration.SignalProcessorConfigurations
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Signals.ISignalProcessorConfigurationList)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("SignalProcessorConfigurations"));
				}
				catch(Scotec.XMLDatabase.DataException e)
				{
					throw new BusinessException((EBusinessError)e.DataError, e.Message, e);
				}
				catch(Exception e)
				{
					throw new BusinessException(EBusinessError.Document, "Caught unhandled exception.", e);
				}
			}
		}
		
		SignalF.Datamodel.Signals.ISignalProcessorDefinitionList IControllerConfiguration.SignalProcessorDefinitions
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Signals.ISignalProcessorDefinitionList)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("SignalProcessorDefinitions"));
				}
				catch(Scotec.XMLDatabase.DataException e)
				{
					throw new BusinessException((EBusinessError)e.DataError, e.Message, e);
				}
				catch(Exception e)
				{
					throw new BusinessException(EBusinessError.Document, "Caught unhandled exception.", e);
				}
			}
		}
		
		SignalF.Datamodel.Signals.ISignalProcessorTemplateList IControllerConfiguration.SignalProcessorTemplates
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Signals.ISignalProcessorTemplateList)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("SignalProcessorTemplates"));
				}
				catch(Scotec.XMLDatabase.DataException e)
				{
					throw new BusinessException((EBusinessError)e.DataError, e.Message, e);
				}
				catch(Exception e)
				{
					throw new BusinessException(EBusinessError.Document, "Caught unhandled exception.", e);
				}
			}
		}
		
		SignalF.Datamodel.Configuration.ITaskConfigurationList IControllerConfiguration.TaskConfigurations
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Configuration.ITaskConfigurationList)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("TaskConfigurations"));
				}
				catch(Scotec.XMLDatabase.DataException e)
				{
					throw new BusinessException((EBusinessError)e.DataError, e.Message, e);
				}
				catch(Exception e)
				{
					throw new BusinessException(EBusinessError.Document, "Caught unhandled exception.", e);
				}
			}
		}
		#endregion Properties


		#region Interface Implementations













		public virtual TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as IControllerConfigurationVisitor<TResult>;
			if (specificVisitor != null)
				return specificVisitor.Visit(this);

			var objectVisitor = visitor as IObjectVisitor<TResult>;
			
			if (objectVisitor != null)
				return objectVisitor.Visit(this);
			throw new NotSupportedException("Visitor of type " + visitor.GetType().FullName + " does not support visiting objects of type " + GetType().FullName + '.');
		}

		#endregion Interface Implementations

	}
}

