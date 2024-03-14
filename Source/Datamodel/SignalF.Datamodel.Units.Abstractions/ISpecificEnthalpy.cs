using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface ISpecificEnthalpy
	{

		#region Properties

		Scotec.Math.Units.SpecificEnthalpy.Units Value{get;set;}

		Scotec.Math.Units.SpecificEnthalpy.Units DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(Scotec.Math.Units.SpecificEnthalpy.Units value);

		#endregion Methods

	}
}

