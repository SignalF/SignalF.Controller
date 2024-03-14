using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial class MCP3008Configuration : SignalF.Datamodel.Hardware.DeviceConfiguration, SignalF.Datamodel.Devices.IMCP3008Configuration
	{
		#region Properties

		
		SignalF.Datamodel.Hardware.ISpiChannelConfiguration IMCP3008Configuration.Channel
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
		
		private const string REFERENCEVOLTAGE_PROPERTY_NAME = "ReferenceVoltage";		
		System.Double IMCP3008Configuration.ReferenceVoltage
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Base.IDouble)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(REFERENCEVOLTAGE_PROPERTY_NAME))).Value;
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
					var attribute = (SignalF.Datamodel.Base.IDouble)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(REFERENCEVOLTAGE_PROPERTY_NAME));
					
					if(attribute.Value == (System.Double)value)
						return;
					
					attribute.Value = (System.Double)value;
					AddModifiedProperty(REFERENCEVOLTAGE_PROPERTY_NAME);
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

		bool  IMCP3008Configuration.HasChannel()
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

		SignalF.Datamodel.Hardware.ISpiChannelConfiguration IMCP3008Configuration.CreateChannel()
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

		TChannel IMCP3008Configuration.CreateChannel<TChannel>()
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

		void  IMCP3008Configuration.DeleteChannel()
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
			var specificVisitor = visitor as IMCP3008ConfigurationVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

