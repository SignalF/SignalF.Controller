using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface IBME280Configuration : SignalF.Datamodel.Hardware.IDeviceConfiguration
	{

		#region Properties

		SignalF.Datamodel.Hardware.ISpiChannelConfiguration Channel { get; }

		#endregion Properties


		#region Methods

		bool HasChannel();
		SignalF.Datamodel.Hardware.ISpiChannelConfiguration CreateChannel();
		TChannel CreateChannel<TChannel>() where TChannel : SignalF.Datamodel.Hardware.ISpiChannelConfiguration;
		void DeleteChannel();

		#endregion Methods

	}

	public interface IBME280ConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IBME280Configuration visitable);
	}
}

