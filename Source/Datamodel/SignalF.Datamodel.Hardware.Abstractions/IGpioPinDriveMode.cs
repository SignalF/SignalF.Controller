using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{

	public enum EGpioPinDriveMode
	{
		Input,
		Output,
		InputPullUp,
		InputPullDown,
		OutputOpenDrain,
		OutputOpenDrainPullUp,
		OutputOpenSource,
		OutputOpenSourcePullDown,
	}

	public partial interface IGpioPinDriveMode
	{

		#region Properties

		EGpioPinDriveMode Value{get;set;}

		EGpioPinDriveMode DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(EGpioPinDriveMode value);

		#endregion Methods

	}
}

