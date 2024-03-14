using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial class TcpDeviceConfiguration : SignalF.Datamodel.Hardware.DeviceConfiguration, SignalF.Datamodel.Devices.ITcpDeviceConfiguration
	{
		#region Properties

		
		SignalF.Datamodel.Hardware.ITcpChannelConfiguration ITcpDeviceConfiguration.Channel
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Hardware.ITcpChannelConfiguration)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("Channel"));
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

		bool  ITcpDeviceConfiguration.HasChannel()
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

		SignalF.Datamodel.Hardware.ITcpChannelConfiguration ITcpDeviceConfiguration.CreateChannel()
		{
			try
			{
				AddModifiedProperty( "Channel" );
				return (SignalF.Datamodel.Hardware.ITcpChannelConfiguration)BusinessSession.Factory.GetBusinessObject(DataObject.CreateDataObject("Channel"));
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

		TChannel ITcpDeviceConfiguration.CreateChannel<TChannel>()
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

		void  ITcpDeviceConfiguration.DeleteChannel()
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
			var specificVisitor = visitor as ITcpDeviceConfigurationVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

