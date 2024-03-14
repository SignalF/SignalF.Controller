using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial class BME280Configuration : SignalF.Datamodel.Hardware.DeviceConfiguration, SignalF.Datamodel.Devices.IBME280Configuration
	{
		#region Properties

		
		SignalF.Datamodel.Hardware.ISpiChannelConfiguration IBME280Configuration.Channel
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
		#endregion Properties


		#region Interface Implementations

		bool  IBME280Configuration.HasChannel()
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

		SignalF.Datamodel.Hardware.ISpiChannelConfiguration IBME280Configuration.CreateChannel()
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

		TChannel IBME280Configuration.CreateChannel<TChannel>()
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

		void  IBME280Configuration.DeleteChannel()
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
			var specificVisitor = visitor as IBME280ConfigurationVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

