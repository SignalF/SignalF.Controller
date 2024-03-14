using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IMolarMassUnit : SignalF.Datamodel.Units.IUnit
	{
		#region Properties

		Scotec.Math.Units.MolarMass.Units Unit { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IMolarMassUnitVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IMolarMassUnit visitable);
	}
}

