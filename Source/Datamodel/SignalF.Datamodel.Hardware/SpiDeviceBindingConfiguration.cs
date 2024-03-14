using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial class SpiDeviceBindingConfiguration : SignalF.Datamodel.Hardware.DeviceBindingConfiguration, SignalF.Datamodel.Hardware.ISpiDeviceBindingConfiguration
	{
		#region Properties

		
		private const string BUSID_PROPERTY_NAME = "BusId";		
		System.Int32 ISpiDeviceBindingConfiguration.BusId
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Base.IInt)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(BUSID_PROPERTY_NAME))).Value;
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
					var attribute = (SignalF.Datamodel.Base.IInt)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(BUSID_PROPERTY_NAME));
					
					if(attribute.Value == (System.Int32)value)
						return;
					
					attribute.Value = (System.Int32)value;
					AddModifiedProperty(BUSID_PROPERTY_NAME);
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
			var specificVisitor = visitor as ISpiDeviceBindingConfigurationVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

