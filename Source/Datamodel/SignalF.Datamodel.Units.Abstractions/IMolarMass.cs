using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IMolarMass
	{

		#region Properties

		Scotec.Math.Units.MolarMass.Units Value{get;set;}

		Scotec.Math.Units.MolarMass.Units DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(Scotec.Math.Units.MolarMass.Units value);

		#endregion Methods

	}
}

