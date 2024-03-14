using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface IMCP4821Configuration : SignalF.Datamodel.Hardware.IDeviceConfiguration
	{

		#region Properties

		SignalF.Datamodel.Hardware.ISpiChannelConfiguration Channel { get; }

		System.UInt32 GainSelect { get; set; }

		#endregion Properties


		#region Methods

		bool HasChannel();
		SignalF.Datamodel.Hardware.ISpiChannelConfiguration CreateChannel();
		TChannel CreateChannel<TChannel>() where TChannel : SignalF.Datamodel.Hardware.ISpiChannelConfiguration;
		void DeleteChannel();

		#endregion Methods

	}

	public interface IMCP4821ConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IMCP4821Configuration visitable);
	}
}

