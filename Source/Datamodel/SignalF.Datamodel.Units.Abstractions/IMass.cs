using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IMass
	{

		#region Properties

		Scotec.Math.Units.Mass.Units Value{get;set;}

		Scotec.Math.Units.Mass.Units DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(Scotec.Math.Units.Mass.Units value);

		#endregion Methods

	}
}

