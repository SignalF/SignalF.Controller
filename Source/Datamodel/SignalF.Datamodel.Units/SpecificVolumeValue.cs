using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial class SpecificVolumeValue : SignalF.Datamodel.Units.Value, SignalF.Datamodel.Units.ISpecificVolumeValue
	{
		#region Properties

		
		private const string UNIT_PROPERTY_NAME = "Unit";		
		Scotec.Math.Units.SpecificVolume.Units ISpecificVolumeValue.Unit
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Units.ISpecificVolume)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(UNIT_PROPERTY_NAME))).Value;
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
					var attribute = (SignalF.Datamodel.Units.ISpecificVolume)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(UNIT_PROPERTY_NAME));
					
					if(attribute.Value == (Scotec.Math.Units.SpecificVolume.Units)value)
						return;
					
					attribute.Value = (Scotec.Math.Units.SpecificVolume.Units)value;
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
	    
		public Scotec.Math.Units.SpecificVolume Value
	    {
	        get
	        {
	            var siValue = ((SignalF.Datamodel.Units.ISpecificVolumeValue)this).SIValue;

	            return siValue == null ? null : new Scotec.Math.Units.SpecificVolume(siValue.Value);
	        }
	        set { ((SignalF.Datamodel.Units.ISpecificVolumeValue)this).SIValue = value?[Scotec.Math.Units.SpecificVolume.SIUnit]; }
	    }
		#endregion Properties


		#region Interface Implementations

		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as ISpecificVolumeValueVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

