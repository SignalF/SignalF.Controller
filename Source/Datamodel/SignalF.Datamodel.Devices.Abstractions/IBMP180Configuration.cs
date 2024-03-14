using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface IBMP180Configuration : SignalF.Datamodel.Hardware.IDeviceConfiguration
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

	public interface IBMP180ConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IBMP180Configuration visitable);
	}
}

