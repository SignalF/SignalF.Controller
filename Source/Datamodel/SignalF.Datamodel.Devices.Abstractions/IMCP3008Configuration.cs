using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface IMCP3008Configuration : SignalF.Datamodel.Hardware.IDeviceConfiguration
	{

		#region Properties

		SignalF.Datamodel.Hardware.ISpiChannelConfiguration Channel { get; }

		System.Double ReferenceVoltage { get; set; }

		#endregion Properties


		#region Methods

		bool HasChannel();
		SignalF.Datamodel.Hardware.ISpiChannelConfiguration CreateChannel();
		TChannel CreateChannel<TChannel>() where TChannel : SignalF.Datamodel.Hardware.ISpiChannelConfiguration;
		void DeleteChannel();

		#endregion Methods

	}

	public interface IMCP3008ConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IMCP3008Configuration visitable);
	}
}

