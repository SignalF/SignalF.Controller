using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial class OPA569Configuration : SignalF.Datamodel.Hardware.DeviceConfiguration, SignalF.Datamodel.Devices.IOPA569Configuration
	{
		#region Properties

		
		SignalF.Datamodel.Hardware.ISpiChannelConfiguration IOPA569Configuration.Channel
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Hardware.ISpiChannelConfiguration)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("Channel"));
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
		
		private const string GPIOPINENABLEFLAG_PROPERTY_NAME = "GpioPinEnableFlag";		
		SignalF.Datamodel.Hardware.IGpioPin IOPA569Configuration.GpioPinEnableFlag
		{
			get
			{
				try
				{
					return BusinessSession.Factory.GetBusinessObject(DataObject.GetReference(GPIOPINENABLEFLAG_PROPERTY_NAME)) as SignalF.Datamodel.Hardware.IGpioPin;
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
					var reference = DataObject.GetReference(GPIOPINENABLEFLAG_PROPERTY_NAME);
					var dataObject = (value!=null) ? ((BusinessObject)value).DataObject : null;

					if(reference == dataObject)
						return;
										
					DataObject.SetReference(GPIOPINENABLEFLAG_PROPERTY_NAME, (value!=null) ? ((BusinessObject)value).DataObject : null);
					AddModifiedProperty(GPIOPINENABLEFLAG_PROPERTY_NAME);
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

		bool  IOPA569Configuration.HasChannel()
		{
			try
			{
				return DataObject.HasDataObject("Channel");
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

		SignalF.Datamodel.Hardware.ISpiChannelConfiguration IOPA569Configuration.CreateChannel()
		{
			try
			{
				AddModifiedProperty( "Channel" );
				return (SignalF.Datamodel.Hardware.ISpiChannelConfiguration)BusinessSession.Factory.GetBusinessObject(DataObject.CreateDataObject("Channel"));
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

		TChannel IOPA569Configuration.CreateChannel<TChannel>()
		{
			try
			{
				Type type = typeof(TChannel);
				string typeName = string.Format("{0}.{1}Type", type.Namespace, type.Name.Substring(1));

				AddModifiedProperty( "Channel" );
				return (TChannel)BusinessSession.Factory.GetBusinessObject(DataObject.CreateDataObject("Channel", typeName));
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

		void  IOPA569Configuration.DeleteChannel()
		{
			try
			{
				AddModifiedProperty( "Channel" );
				DataObject.DeleteDataObject("Channel");
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



		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as IOPA569ConfigurationVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

