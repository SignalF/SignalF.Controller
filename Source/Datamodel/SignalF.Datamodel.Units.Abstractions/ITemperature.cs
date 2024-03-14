using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface ITemperature
	{

		#region Properties

		Scotec.Math.Units.Temperature.Units Value{get;set;}

		Scotec.Math.Units.Temperature.Units DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(Scotec.Math.Units.Temperature.Units value);

		#endregion Methods

	}
}

