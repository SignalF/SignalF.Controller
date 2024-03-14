using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IAngle
	{

		#region Properties

		Scotec.Math.Units.Angle.Units Value{get;set;}

		Scotec.Math.Units.Angle.Units DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(Scotec.Math.Units.Angle.Units value);

		#endregion Methods

	}
}

