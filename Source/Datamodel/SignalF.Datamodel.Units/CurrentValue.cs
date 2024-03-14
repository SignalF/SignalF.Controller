using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial class CurrentValue : SignalF.Datamodel.Units.Value, SignalF.Datamodel.Units.ICurrentValue
	{
		#region Properties

		
		private const string UNIT_PROPERTY_NAME = "Unit";		
		Scotec.Math.Units.Current.Units ICurrentValue.Unit
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Units.ICurrent)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(UNIT_PROPERTY_NAME))).Value;
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
					var attribute = (SignalF.Datamodel.Units.ICurrent)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(UNIT_PROPERTY_NAME));
					
					if(attribute.Value == (Scotec.Math.Units.Current.Units)value)
						return;
					
					attribute.Value = (Scotec.Math.Units.Current.Units)value;
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
	    
		public Scotec.Math.Units.Current Value
	    {
	        get
	        {
	            var siValue = ((SignalF.Datamodel.Units.ICurrentValue)this).SIValue;

	            return siValue == null ? null : new Scotec.Math.Units.Current(siValue.Value);
	        }
	        set { ((SignalF.Datamodel.Units.ICurrentValue)this).SIValue = value?[Scotec.Math.Units.Current.SIUnit]; }
	    }
		#endregion Properties


		#region Interface Implementations

		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as ICurrentValueVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

