using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IPressure
	{

		#region Properties

		Scotec.Math.Units.Pressure.Units Value{get;set;}

		Scotec.Math.Units.Pressure.Units DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(Scotec.Math.Units.Pressure.Units value);

		#endregion Methods

	}
}

