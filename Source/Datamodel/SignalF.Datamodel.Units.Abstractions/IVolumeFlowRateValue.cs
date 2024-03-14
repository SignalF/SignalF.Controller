using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IVolumeFlowRateValue : SignalF.Datamodel.Units.IValue
	{
		#region Properties

		Scotec.Math.Units.VolumeFlowRate.Units Unit { get; set; }
		Scotec.Math.Units.VolumeFlowRate Value { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IVolumeFlowRateValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IVolumeFlowRateValue visitable);
	}
}

