using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial class PressureValue : SignalF.Datamodel.Units.Value, SignalF.Datamodel.Units.IPressureValue
	{
		#region Properties

		
		private const string UNIT_PROPERTY_NAME = "Unit";		
		Scotec.Math.Units.Pressure.Units IPressureValue.Unit
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Units.IPressure)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(UNIT_PROPERTY_NAME))).Value;
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
					var attribute = (SignalF.Datamodel.Units.IPressure)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(UNIT_PROPERTY_NAME));
					
					if(attribute.Value == (Scotec.Math.Units.Pressure.Units)value)
						return;
					
					attribute.Value = (Scotec.Math.Units.Pressure.Units)value;
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
	    
		public Scotec.Math.Units.Pressure Value
	    {
	        get
	        {
	            var siValue = ((SignalF.Datamodel.Units.IPressureValue)this).SIValue;

	            return siValue == null ? null : new Scotec.Math.Units.Pressure(siValue.Value);
	        }
	        set { ((SignalF.Datamodel.Units.IPressureValue)this).SIValue = value?[Scotec.Math.Units.Pressure.SIUnit]; }
	    }
		#endregion Properties


		#region Interface Implementations

		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as IPressureValueVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

