using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IDynamicViscosityUnit : SignalF.Datamodel.Units.IUnit
	{
		#region Properties

		Scotec.Math.Units.DynamicViscosity.Units Unit { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IDynamicViscosityUnitVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IDynamicViscosityUnit visitable);
	}
}

