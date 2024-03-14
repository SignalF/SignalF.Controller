using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial class VoltageValue : SignalF.Datamodel.Units.Value, SignalF.Datamodel.Units.IVoltageValue
	{
		#region Properties

		
		private const string UNIT_PROPERTY_NAME = "Unit";		
		Scotec.Math.Units.Voltage.Units IVoltageValue.Unit
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Units.IVoltage)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(UNIT_PROPERTY_NAME))).Value;
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
					var attribute = (SignalF.Datamodel.Units.IVoltage)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(UNIT_PROPERTY_NAME));
					
					if(attribute.Value == (Scotec.Math.Units.Voltage.Units)value)
						return;
					
					attribute.Value = (Scotec.Math.Units.Voltage.Units)value;
					AddModifiedProperty(UNIT_PROPERTY_NAME);
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
	    
		public Scotec.Math.Units.Voltage Value
	    {
	        get
	        {
	            var siValue = ((SignalF.Datamodel.Units.IVoltageValue)this).SIValue;

	            return siValue == null ? null : new Scotec.Math.Units.Voltage(siValue.Value);
	        }
	        set { ((SignalF.Datamodel.Units.IVoltageValue)this).SIValue = value?[Scotec.Math.Units.Voltage.SIUnit]; }
	    }
		#endregion Properties


		#region Interface Implementations

		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as IVoltageValueVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

