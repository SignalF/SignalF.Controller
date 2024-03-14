using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial class SpiChannelConfiguration : SignalF.Datamodel.Hardware.ChannelConfiguration, SignalF.Datamodel.Hardware.ISpiChannelConfiguration
	{
		#region Properties

		
		private const string CHIPSELECTLINE_PROPERTY_NAME = "ChipSelectLine";		
		System.Int32 ISpiChannelConfiguration.ChipSelectLine
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Base.IInt)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(CHIPSELECTLINE_PROPERTY_NAME))).Value;
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
					var attribute = (SignalF.Datamodel.Base.IInt)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(CHIPSELECTLINE_PROPERTY_NAME));
					
					if(attribute.Value == (System.Int32)value)
						return;
					
					attribute.Value = (System.Int32)value;
					AddModifiedProperty(CHIPSELECTLINE_PROPERTY_NAME);
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
		
		private const string CHIPSELECTLINEACTIVESTATE_PROPERTY_NAME = "ChipSelectLineActiveState";		
		SignalF.Datamodel.Hardware.EGpioPinValue? ISpiChannelConfiguration.ChipSelectLineActiveState
		{
			get
			{
				try
				{
					if(DataObject.HasAttribute(CHIPSELECTLINEACTIVESTATE_PROPERTY_NAME))
						return ((SignalF.Datamodel.Hardware.IGpioPinValue)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(CHIPSELECTLINEACTIVESTATE_PROPERTY_NAME))).Value;
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
						if(DataObject.HasAttribute(CHIPSELECTLINEACTIVESTATE_PROPERTY_NAME))
						{
							DataObject.DeleteAttribute(CHIPSELECTLINEACTIVESTATE_PROPERTY_NAME);
							AddModifiedProperty( CHIPSELECTLINEACTIVESTATE_PROPERTY_NAME );
						}
					}
					else
					{
						if(DataObject.HasAttribute(CHIPSELECTLINEACTIVESTATE_PROPERTY_NAME))
						{
							var attribute = (SignalF.Datamodel.Hardware.IGpioPinValue)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(CHIPSELECTLINEACTIVESTATE_PROPERTY_NAME));
							if(attribute.Value == (SignalF.Datamodel.Hardware.EGpioPinValue)value)
								return;

							attribute.Value = (SignalF.Datamodel.Hardware.EGpioPinValue)value;
							AddModifiedProperty(CHIPSELECTLINEACTIVESTATE_PROPERTY_NAME);
						}
						else
						{
							((SignalF.Datamodel.Hardware.IGpioPinValue)BusinessSession.Factory.GetBusinessAttribute(DataObject.CreateAttribute(CHIPSELECTLINEACTIVESTATE_PROPERTY_NAME))).Value = (SignalF.Datamodel.Hardware.EGpioPinValue)value;
							AddModifiedProperty(CHIPSELECTLINEACTIVESTATE_PROPERTY_NAME);
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
		
		private const string CLOCKFREQUENCY_PROPERTY_NAME = "ClockFrequency";		
		System.Int32? ISpiChannelConfiguration.ClockFrequency
		{
			get
			{
				try
				{
					if(DataObject.HasAttribute(CLOCKFREQUENCY_PROPERTY_NAME))
						return ((SignalF.Datamodel.Base.IInt)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(CLOCKFREQUENCY_PROPERTY_NAME))).Value;
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
						if(DataObject.HasAttribute(CLOCKFREQUENCY_PROPERTY_NAME))
						{
							DataObject.DeleteAttribute(CLOCKFREQUENCY_PROPERTY_NAME);
							AddModifiedProperty( CLOCKFREQUENCY_PROPERTY_NAME );
						}
					}
					else
					{
						if(DataObject.HasAttribute(CLOCKFREQUENCY_PROPERTY_NAME))
						{
							var attribute = (SignalF.Datamodel.Base.IInt)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(CLOCKFREQUENCY_PROPERTY_NAME));
							if(attribute.Value == (System.Int32)value)
								return;

							attribute.Value = (System.Int32)value;
							AddModifiedProperty(CLOCKFREQUENCY_PROPERTY_NAME);
						}
						else
						{
							((SignalF.Datamodel.Base.IInt)BusinessSession.Factory.GetBusinessAttribute(DataObject.CreateAttribute(CLOCKFREQUENCY_PROPERTY_NAME))).Value = (System.Int32)value;
							AddModifiedProperty(CLOCKFREQUENCY_PROPERTY_NAME);
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
		
		private const string DATABITLENGTH_PROPERTY_NAME = "DataBitLength";		
		System.Int32? ISpiChannelConfiguration.DataBitLength
		{
			get
			{
				try
				{
					if(DataObject.HasAttribute(DATABITLENGTH_PROPERTY_NAME))
						return ((SignalF.Datamodel.Base.IInt)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(DATABITLENGTH_PROPERTY_NAME))).Value;
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
						if(DataObject.HasAttribute(DATABITLENGTH_PROPERTY_NAME))
						{
							DataObject.DeleteAttribute(DATABITLENGTH_PROPERTY_NAME);
							AddModifiedProperty( DATABITLENGTH_PROPERTY_NAME );
						}
					}
					else
					{
						if(DataObject.HasAttribute(DATABITLENGTH_PROPERTY_NAME))
						{
							var attribute = (SignalF.Datamodel.Base.IInt)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(DATABITLENGTH_PROPERTY_NAME));
							if(attribute.Value == (System.Int32)value)
								return;

							attribute.Value = (System.Int32)value;
							AddModifiedProperty(DATABITLENGTH_PROPERTY_NAME);
						}
						else
						{
							((SignalF.Datamodel.Base.IInt)BusinessSession.Factory.GetBusinessAttribute(DataObject.CreateAttribute(DATABITLENGTH_PROPERTY_NAME))).Value = (System.Int32)value;
							AddModifiedProperty(DATABITLENGTH_PROPERTY_NAME);
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
		
		private const string DATAFLOW_PROPERTY_NAME = "DataFlow";		
		SignalF.Datamodel.Hardware.ESpiDataFlow? ISpiChannelConfiguration.DataFlow
		{
			get
			{
				try
				{
					if(DataObject.HasAttribute(DATAFLOW_PROPERTY_NAME))
						return ((SignalF.Datamodel.Hardware.ISpiDataFlow)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(DATAFLOW_PROPERTY_NAME))).Value;
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
						if(DataObject.HasAttribute(DATAFLOW_PROPERTY_NAME))
						{
							DataObject.DeleteAttribute(DATAFLOW_PROPERTY_NAME);
							AddModifiedProperty( DATAFLOW_PROPERTY_NAME );
						}
					}
					else
					{
						if(DataObject.HasAttribute(DATAFLOW_PROPERTY_NAME))
						{
							var attribute = (SignalF.Datamodel.Hardware.ISpiDataFlow)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(DATAFLOW_PROPERTY_NAME));
							if(attribute.Value == (SignalF.Datamodel.Hardware.ESpiDataFlow)value)
								return;

							attribute.Value = (SignalF.Datamodel.Hardware.ESpiDataFlow)value;
							AddModifiedProperty(DATAFLOW_PROPERTY_NAME);
						}
						else
						{
							((SignalF.Datamodel.Hardware.ISpiDataFlow)BusinessSession.Factory.GetBusinessAttribute(DataObject.CreateAttribute(DATAFLOW_PROPERTY_NAME))).Value = (SignalF.Datamodel.Hardware.ESpiDataFlow)value;
							AddModifiedProperty(DATAFLOW_PROPERTY_NAME);
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
		
		private const string MODE_PROPERTY_NAME = "Mode";		
		SignalF.Datamodel.Hardware.ESpiMode ISpiChannelConfiguration.Mode
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Hardware.ISpiMode)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(MODE_PROPERTY_NAME))).Value;
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
					var attribute = (SignalF.Datamodel.Hardware.ISpiMode)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(MODE_PROPERTY_NAME));
					
					if(attribute.Value == (SignalF.Datamodel.Hardware.ESpiMode)value)
						return;
					
					attribute.Value = (SignalF.Datamodel.Hardware.ESpiMode)value;
					AddModifiedProperty(MODE_PROPERTY_NAME);
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
			var specificVisitor = visitor as ISpiChannelConfigurationVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

