using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IDynamicViscosity
	{

		#region Properties

		Scotec.Math.Units.DynamicViscosity.Units Value{get;set;}

		Scotec.Math.Units.DynamicViscosity.Units DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(Scotec.Math.Units.DynamicViscosity.Units value);

		#endregion Methods

	}
}

