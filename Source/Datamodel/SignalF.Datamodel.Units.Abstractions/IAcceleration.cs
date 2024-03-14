using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IAcceleration
	{

		#region Properties

		Scotec.Math.Units.Acceleration.Units Value{get;set;}

		Scotec.Math.Units.Acceleration.Units DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(Scotec.Math.Units.Acceleration.Units value);

		#endregion Methods

	}
}

