using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial class DeviceDefinition : SignalF.Datamodel.Signals.SignalProcessorDefinition, SignalF.Datamodel.Hardware.IDeviceDefinition
	{
		#region Properties

		
		private const string CONNECTIONTYPE_PROPERTY_NAME = "ConnectionType";		
		SignalF.Datamodel.Hardware.EConnectionType IDeviceDefinition.ConnectionType
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Hardware.IConnectionType)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(CONNECTIONTYPE_PROPERTY_NAME))).Value;
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
					var attribute = (SignalF.Datamodel.Hardware.IConnectionType)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(CONNECTIONTYPE_PROPERTY_NAME));
					
					if(attribute.Value == (SignalF.Datamodel.Hardware.EConnectionType)value)
						return;
					
					attribute.Value = (SignalF.Datamodel.Hardware.EConnectionType)value;
					AddModifiedProperty(CONNECTIONTYPE_PROPERTY_NAME);
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
			var specificVisitor = visitor as IDeviceDefinitionVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

