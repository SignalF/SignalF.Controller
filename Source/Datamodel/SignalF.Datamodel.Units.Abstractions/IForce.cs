using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IForce
	{

		#region Properties

		Scotec.Math.Units.Force.Units Value{get;set;}

		Scotec.Math.Units.Force.Units DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(Scotec.Math.Units.Force.Units value);

		#endregion Methods

	}
}

