using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IVoltageUnit : SignalF.Datamodel.Units.IUnit
	{
		#region Properties

		Scotec.Math.Units.Voltage.Units Unit { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IVoltageUnitVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IVoltageUnit visitable);
	}
}

