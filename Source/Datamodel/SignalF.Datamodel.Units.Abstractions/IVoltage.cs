using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IVoltage
	{

		#region Properties

		Scotec.Math.Units.Voltage.Units Value{get;set;}

		Scotec.Math.Units.Voltage.Units DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(Scotec.Math.Units.Voltage.Units value);

		#endregion Methods

	}
}

