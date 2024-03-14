using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IVelocity
	{

		#region Properties

		Scotec.Math.Units.Velocity.Units Value{get;set;}

		Scotec.Math.Units.Velocity.Units DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(Scotec.Math.Units.Velocity.Units value);

		#endregion Methods

	}
}

