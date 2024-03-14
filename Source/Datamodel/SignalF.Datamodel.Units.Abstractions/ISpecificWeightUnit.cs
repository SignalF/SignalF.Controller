using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface ISpecificWeightUnit : SignalF.Datamodel.Units.IUnit
	{
		#region Properties

		Scotec.Math.Units.SpecificWeight.Units Unit { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ISpecificWeightUnitVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISpecificWeightUnit visitable);
	}
}

