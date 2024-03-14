using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IPressureUnit : SignalF.Datamodel.Units.IUnit
	{
		#region Properties

		Scotec.Math.Units.Pressure.Units Unit { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IPressureUnitVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IPressureUnit visitable);
	}
}

