using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface II2cDeviceConfiguration : SignalF.Datamodel.Hardware.IDeviceConfiguration
	{

		#region Properties

		SignalF.Datamodel.Hardware.II2cChannelConfiguration Channel { get; }

		#endregion Properties


		#region Methods

		bool HasChannel();
		SignalF.Datamodel.Hardware.II2cChannelConfiguration CreateChannel();
		TChannel CreateChannel<TChannel>() where TChannel : SignalF.Datamodel.Hardware.II2cChannelConfiguration;
		void DeleteChannel();

		#endregion Methods

	}

	public interface II2cDeviceConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(II2cDeviceConfiguration visitable);
	}
}

