using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial class BMP180Configuration : SignalF.Datamodel.Hardware.DeviceConfiguration, SignalF.Datamodel.Devices.IBMP180Configuration
	{
		#region Properties

		
		SignalF.Datamodel.Hardware.II2cChannelConfiguration IBMP180Configuration.Channel
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Hardware.II2cChannelConfiguration)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("Channel"));
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

		bool  IBMP180Configuration.HasChannel()
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

		SignalF.Datamodel.Hardware.II2cChannelConfiguration IBMP180Configuration.CreateChannel()
		{
			try
			{
				AddModifiedProperty( "Channel" );
				return (SignalF.Datamodel.Hardware.II2cChannelConfiguration)BusinessSession.Factory.GetBusinessObject(DataObject.CreateDataObject("Channel"));
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

		TChannel IBMP180Configuration.CreateChannel<TChannel>()
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

		void  IBMP180Configuration.DeleteChannel()
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
			var specificVisitor = visitor as IBMP180ConfigurationVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

