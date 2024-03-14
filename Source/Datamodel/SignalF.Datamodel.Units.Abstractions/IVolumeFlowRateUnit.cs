using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IVolumeFlowRateUnit : SignalF.Datamodel.Units.IUnit
	{
		#region Properties

		Scotec.Math.Units.VolumeFlowRate.Units Unit { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IVolumeFlowRateUnitVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IVolumeFlowRateUnit visitable);
	}
}

