using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IMassFlux
	{

		#region Properties

		Scotec.Math.Units.MassFlux.Units Value{get;set;}

		Scotec.Math.Units.MassFlux.Units DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(Scotec.Math.Units.MassFlux.Units value);

		#endregion Methods

	}
}

