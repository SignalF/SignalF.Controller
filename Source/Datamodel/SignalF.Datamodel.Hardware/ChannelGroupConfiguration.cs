using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public abstract partial class ChannelGroupConfiguration : SignalF.Datamodel.Base.CoreObject, SignalF.Datamodel.Hardware.IChannelGroupConfiguration
	{
		#region Properties

		
		SignalF.Datamodel.Hardware.IChannelConfigurationList IChannelGroupConfiguration.Channels
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Hardware.IChannelConfigurationList)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("Channels"));
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
		
		private const string DEVICEBINDING_PROPERTY_NAME = "DeviceBinding";		
		SignalF.Datamodel.Hardware.IDeviceBindingConfiguration IChannelGroupConfiguration.DeviceBinding
		{
			get
			{
				try
				{
					return BusinessSession.Factory.GetBusinessObject(DataObject.GetReference(DEVICEBINDING_PROPERTY_NAME)) as SignalF.Datamodel.Hardware.IDeviceBindingConfiguration;
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
			set
			{
				try
				{
					var reference = DataObject.GetReference(DEVICEBINDING_PROPERTY_NAME);
					var dataObject = (value!=null) ? ((BusinessObject)value).DataObject : null;

					if(reference == dataObject)
						return;
										
					DataObject.SetReference(DEVICEBINDING_PROPERTY_NAME, (value!=null) ? ((BusinessObject)value).DataObject : null);
					AddModifiedProperty(DEVICEBINDING_PROPERTY_NAME);
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



		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as IChannelGroupConfigurationVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

