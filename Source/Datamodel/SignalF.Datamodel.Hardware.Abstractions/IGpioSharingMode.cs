using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{

	public enum EGpioSharingMode
	{
		Exclusive,
		SharedReadOnly,
	}

	public partial interface IGpioSharingMode
	{

		#region Properties

		EGpioSharingMode Value{get;set;}

		EGpioSharingMode DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(EGpioSharingMode value);

		#endregion Methods

	}
}

