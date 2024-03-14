using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IMassFlowRateUnit : SignalF.Datamodel.Units.IUnit
	{
		#region Properties

		Scotec.Math.Units.MassFlowRate.Units Unit { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IMassFlowRateUnitVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IMassFlowRateUnit visitable);
	}
}

