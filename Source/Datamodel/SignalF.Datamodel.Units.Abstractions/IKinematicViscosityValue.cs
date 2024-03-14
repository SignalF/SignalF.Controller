using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IKinematicViscosityValue : SignalF.Datamodel.Units.IValue
	{
		#region Properties

		Scotec.Math.Units.KinematicViscosity.Units Unit { get; set; }
		Scotec.Math.Units.KinematicViscosity Value { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IKinematicViscosityValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IKinematicViscosityValue visitable);
	}
}

