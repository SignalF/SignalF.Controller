using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IKinematicViscosityUnit : SignalF.Datamodel.Units.IUnit
	{
		#region Properties

		Scotec.Math.Units.KinematicViscosity.Units Unit { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IKinematicViscosityUnitVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IKinematicViscosityUnit visitable);
	}
}

