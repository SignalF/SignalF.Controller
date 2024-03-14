using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{

	public enum ESpiDataFlow
	{
		MsbFirst,
		LsbFirst,
	}

	public partial interface ISpiDataFlow
	{

		#region Properties

		ESpiDataFlow Value{get;set;}

		ESpiDataFlow DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(ESpiDataFlow value);

		#endregion Methods

	}
}

