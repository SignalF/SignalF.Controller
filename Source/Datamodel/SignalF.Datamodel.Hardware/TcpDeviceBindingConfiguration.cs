using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial class TcpDeviceBindingConfiguration : SignalF.Datamodel.Hardware.DeviceBindingConfiguration, SignalF.Datamodel.Hardware.ITcpDeviceBindingConfiguration
	{
		#region Properties

		
		private const string IPADDRESS_PROPERTY_NAME = "IpAddress";		
		System.String ITcpDeviceBindingConfiguration.IpAddress
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Base.IString)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(IPADDRESS_PROPERTY_NAME))).Value;
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
					if(value == null)
						throw new ArgumentException("Value must not be null.");
					var attribute = (SignalF.Datamodel.Base.IString)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(IPADDRESS_PROPERTY_NAME));
					
					if(attribute.Value == (System.String)value)
						return;
					
					attribute.Value = (System.String)value;
					AddModifiedProperty(IPADDRESS_PROPERTY_NAME);
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
			var specificVisitor = visitor as ITcpDeviceBindingConfigurationVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

