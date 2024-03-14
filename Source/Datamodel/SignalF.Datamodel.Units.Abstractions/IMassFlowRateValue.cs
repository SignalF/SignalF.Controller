using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IMassFlowRateValue : SignalF.Datamodel.Units.IValue
	{
		#region Properties

		Scotec.Math.Units.MassFlowRate.Units Unit { get; set; }
		Scotec.Math.Units.MassFlowRate Value { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IMassFlowRateValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IMassFlowRateValue visitable);
	}
}

