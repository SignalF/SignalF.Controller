using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface IOPA569Configuration : SignalF.Datamodel.Hardware.IDeviceConfiguration
	{

		#region Properties

		SignalF.Datamodel.Hardware.ISpiChannelConfiguration Channel { get; }

		SignalF.Datamodel.Hardware.IGpioPin GpioPinEnableFlag { get; set; }

		#endregion Properties


		#region Methods

		bool HasChannel();
		SignalF.Datamodel.Hardware.ISpiChannelConfiguration CreateChannel();
		TChannel CreateChannel<TChannel>() where TChannel : SignalF.Datamodel.Hardware.ISpiChannelConfiguration;
		void DeleteChannel();


		#endregion Methods

	}

	public interface IOPA569ConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IOPA569Configuration visitable);
	}
}

