using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface ISpecificWeight
	{

		#region Properties

		Scotec.Math.Units.SpecificWeight.Units Value{get;set;}

		Scotec.Math.Units.SpecificWeight.Units DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(Scotec.Math.Units.SpecificWeight.Units value);

		#endregion Methods

	}
}

