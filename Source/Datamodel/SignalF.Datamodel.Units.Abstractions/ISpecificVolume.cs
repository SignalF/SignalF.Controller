using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface ISpecificVolume
	{

		#region Properties

		Scotec.Math.Units.SpecificVolume.Units Value{get;set;}

		Scotec.Math.Units.SpecificVolume.Units DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(Scotec.Math.Units.SpecificVolume.Units value);

		#endregion Methods

	}
}

