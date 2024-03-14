using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IDensity
	{

		#region Properties

		Scotec.Math.Units.Density.Units Value{get;set;}

		Scotec.Math.Units.Density.Units DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(Scotec.Math.Units.Density.Units value);

		#endregion Methods

	}
}

