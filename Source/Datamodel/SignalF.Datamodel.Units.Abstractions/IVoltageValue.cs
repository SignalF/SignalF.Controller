using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IVoltageValue : SignalF.Datamodel.Units.IValue
	{
		#region Properties

		Scotec.Math.Units.Voltage.Units Unit { get; set; }
		Scotec.Math.Units.Voltage Value { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IVoltageValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IVoltageValue visitable);
	}
}

