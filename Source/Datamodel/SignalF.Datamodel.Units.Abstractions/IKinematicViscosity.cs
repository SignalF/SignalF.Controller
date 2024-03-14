using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IKinematicViscosity
	{

		#region Properties

		Scotec.Math.Units.KinematicViscosity.Units Value{get;set;}

		Scotec.Math.Units.KinematicViscosity.Units DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(Scotec.Math.Units.KinematicViscosity.Units value);

		#endregion Methods

	}
}

