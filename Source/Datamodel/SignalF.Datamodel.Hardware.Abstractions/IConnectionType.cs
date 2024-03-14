using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{

	public enum EConnectionType
	{
		None,
		I2c,
		Spi,
		OneWire,
		USB,
		Tcp,
		UDP,
		RS232,
	}

	public partial interface IConnectionType
	{

		#region Properties

		EConnectionType Value{get;set;}

		EConnectionType DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(EConnectionType value);

		#endregion Methods

	}
}

