using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{

	public enum EGpioPinValue
	{
		Low,
		High,
	}

	public partial interface IGpioPinValue
	{

		#region Properties

		EGpioPinValue Value{get;set;}

		EGpioPinValue DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(EGpioPinValue value);

		#endregion Methods

	}
}

