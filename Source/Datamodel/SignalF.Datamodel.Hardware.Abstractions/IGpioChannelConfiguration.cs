using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface IGpioChannelConfiguration : SignalF.Datamodel.Hardware.IChannelConfiguration
	{

		#region Properties

		SignalF.Datamodel.Hardware.EGpioPinDriveMode DriveMode { get; set; }

		SignalF.Datamodel.Hardware.EGpioPinValue? InitialValue { get; set; }

		System.Int32 PinNumber { get; set; }

		SignalF.Datamodel.Hardware.EGpioSharingMode SharingMode { get; set; }

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IGpioChannelConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IGpioChannelConfiguration visitable);
	}
}

