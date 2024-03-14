using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IPressureValue : SignalF.Datamodel.Units.IValue
	{
		#region Properties

		Scotec.Math.Units.Pressure.Units Unit { get; set; }
		Scotec.Math.Units.Pressure Value { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IPressureValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IPressureValue visitable);
	}
}

