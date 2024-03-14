using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial class VolumeFlowRateValue : SignalF.Datamodel.Units.Value, SignalF.Datamodel.Units.IVolumeFlowRateValue
	{
		#region Properties

		
		private const string UNIT_PROPERTY_NAME = "Unit";		
		Scotec.Math.Units.VolumeFlowRate.Units IVolumeFlowRateValue.Unit
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Units.IVolumeFlowRate)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(UNIT_PROPERTY_NAME))).Value;
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
					var attribute = (SignalF.Datamodel.Units.IVolumeFlowRate)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(UNIT_PROPERTY_NAME));
					
					if(attribute.Value == (Scotec.Math.Units.VolumeFlowRate.Units)value)
						return;
					
					attribute.Value = (Scotec.Math.Units.VolumeFlowRate.Units)value;
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
	    
		public Scotec.Math.Units.VolumeFlowRate Value
	    {
	        get
	        {
	            var siValue = ((SignalF.Datamodel.Units.IVolumeFlowRateValue)this).SIValue;

	            return siValue == null ? null : new Scotec.Math.Units.VolumeFlowRate(siValue.Value);
	        }
	        set { ((SignalF.Datamodel.Units.IVolumeFlowRateValue)this).SIValue = value?[Scotec.Math.Units.VolumeFlowRate.SIUnit]; }
	    }
		#endregion Properties


		#region Interface Implementations

		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as IVolumeFlowRateValueVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

