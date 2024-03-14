using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IVelocityUnit : SignalF.Datamodel.Units.IUnit
	{
		#region Properties

		Scotec.Math.Units.Velocity.Units Unit { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IVelocityUnitVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IVelocityUnit visitable);
	}
}

