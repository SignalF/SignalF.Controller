using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IDensityUnit : SignalF.Datamodel.Units.IUnit
	{
		#region Properties

		Scotec.Math.Units.Density.Units Unit { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IDensityUnitVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IDensityUnit visitable);
	}
}

