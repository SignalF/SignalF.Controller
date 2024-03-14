using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial class MassValue : SignalF.Datamodel.Units.Value, SignalF.Datamodel.Units.IMassValue
	{
		#region Properties

		
		private const string UNIT_PROPERTY_NAME = "Unit";		
		Scotec.Math.Units.Mass.Units IMassValue.Unit
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Units.IMass)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(UNIT_PROPERTY_NAME))).Value;
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
					var attribute = (SignalF.Datamodel.Units.IMass)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(UNIT_PROPERTY_NAME));
					
					if(attribute.Value == (Scotec.Math.Units.Mass.Units)value)
						return;
					
					attribute.Value = (Scotec.Math.Units.Mass.Units)value;
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
	    
		public Scotec.Math.Units.Mass Value
	    {
	        get
	        {
	            var siValue = ((SignalF.Datamodel.Units.IMassValue)this).SIValue;

	            return siValue == null ? null : new Scotec.Math.Units.Mass(siValue.Value);
	        }
	        set { ((SignalF.Datamodel.Units.IMassValue)this).SIValue = value?[Scotec.Math.Units.Mass.SIUnit]; }
	    }
		#endregion Properties


		#region Interface Implementations

		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as IMassValueVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

