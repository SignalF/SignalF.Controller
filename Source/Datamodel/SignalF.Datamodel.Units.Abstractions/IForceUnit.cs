using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IForceUnit : SignalF.Datamodel.Units.IUnit
	{
		#region Properties

		Scotec.Math.Units.Force.Units Unit { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IForceUnitVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IForceUnit visitable);
	}
}

