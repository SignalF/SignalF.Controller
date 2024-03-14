using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial class GpioChannelConfiguration : SignalF.Datamodel.Hardware.ChannelConfiguration, SignalF.Datamodel.Hardware.IGpioChannelConfiguration
	{
		#region Properties

		
		private const string DRIVEMODE_PROPERTY_NAME = "DriveMode";		
		SignalF.Datamodel.Hardware.EGpioPinDriveMode IGpioChannelConfiguration.DriveMode
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Hardware.IGpioPinDriveMode)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(DRIVEMODE_PROPERTY_NAME))).Value;
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
					var attribute = (SignalF.Datamodel.Hardware.IGpioPinDriveMode)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(DRIVEMODE_PROPERTY_NAME));
					
					if(attribute.Value == (SignalF.Datamodel.Hardware.EGpioPinDriveMode)value)
						return;
					
					attribute.Value = (SignalF.Datamodel.Hardware.EGpioPinDriveMode)value;
					AddModifiedProperty(DRIVEMODE_PROPERTY_NAME);
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
		
		private const string INITIALVALUE_PROPERTY_NAME = "InitialValue";		
		SignalF.Datamodel.Hardware.EGpioPinValue? IGpioChannelConfiguration.InitialValue
		{
			get
			{
				try
				{
					if(DataObject.HasAttribute(INITIALVALUE_PROPERTY_NAME))
						return ((SignalF.Datamodel.Hardware.IGpioPinValue)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(INITIALVALUE_PROPERTY_NAME))).Value;
					return null;
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
					{
						if(DataObject.HasAttribute(INITIALVALUE_PROPERTY_NAME))
						{
							DataObject.DeleteAttribute(INITIALVALUE_PROPERTY_NAME);
							AddModifiedProperty( INITIALVALUE_PROPERTY_NAME );
						}
					}
					else
					{
						if(DataObject.HasAttribute(INITIALVALUE_PROPERTY_NAME))
						{
							var attribute = (SignalF.Datamodel.Hardware.IGpioPinValue)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(INITIALVALUE_PROPERTY_NAME));
							if(attribute.Value == (SignalF.Datamodel.Hardware.EGpioPinValue)value)
								return;

							attribute.Value = (SignalF.Datamodel.Hardware.EGpioPinValue)value;
							AddModifiedProperty(INITIALVALUE_PROPERTY_NAME);
						}
						else
						{
							((SignalF.Datamodel.Hardware.IGpioPinValue)BusinessSession.Factory.GetBusinessAttribute(DataObject.CreateAttribute(INITIALVALUE_PROPERTY_NAME))).Value = (SignalF.Datamodel.Hardware.EGpioPinValue)value;
							AddModifiedProperty(INITIALVALUE_PROPERTY_NAME);
						}
					}
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
		
		private const string PINNUMBER_PROPERTY_NAME = "PinNumber";		
		System.Int32 IGpioChannelConfiguration.PinNumber
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Base.IInt)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(PINNUMBER_PROPERTY_NAME))).Value;
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
					var attribute = (SignalF.Datamodel.Base.IInt)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(PINNUMBER_PROPERTY_NAME));
					
					if(attribute.Value == (System.Int32)value)
						return;
					
					attribute.Value = (System.Int32)value;
					AddModifiedProperty(PINNUMBER_PROPERTY_NAME);
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
		
		private const string SHARINGMODE_PROPERTY_NAME = "SharingMode";		
		SignalF.Datamodel.Hardware.EGpioSharingMode IGpioChannelConfiguration.SharingMode
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Hardware.IGpioSharingMode)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(SHARINGMODE_PROPERTY_NAME))).Value;
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
					var attribute = (SignalF.Datamodel.Hardware.IGpioSharingMode)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(SHARINGMODE_PROPERTY_NAME));
					
					if(attribute.Value == (SignalF.Datamodel.Hardware.EGpioSharingMode)value)
						return;
					
					attribute.Value = (SignalF.Datamodel.Hardware.EGpioSharingMode)value;
					AddModifiedProperty(SHARINGMODE_PROPERTY_NAME);
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
			var specificVisitor = visitor as IGpioChannelConfigurationVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

