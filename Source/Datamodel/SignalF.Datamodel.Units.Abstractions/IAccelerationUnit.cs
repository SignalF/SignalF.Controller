using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IAccelerationUnit : SignalF.Datamodel.Units.IUnit
	{
		#region Properties

		Scotec.Math.Units.Acceleration.Units Unit { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IAccelerationUnitVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IAccelerationUnit visitable);
	}
}

