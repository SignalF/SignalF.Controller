using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface ISpecificEnthalpyUnit : SignalF.Datamodel.Units.IUnit
	{
		#region Properties

		Scotec.Math.Units.SpecificEnthalpy.Units Unit { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ISpecificEnthalpyUnitVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISpecificEnthalpyUnit visitable);
	}
}

