using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{

	public enum EI2cBusSpeed
	{
		StandardMode,
		FastMode,
	}

	public partial interface II2cBusSpeed
	{

		#region Properties

		EI2cBusSpeed Value{get;set;}

		EI2cBusSpeed DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(EI2cBusSpeed value);

		#endregion Methods

	}
}

