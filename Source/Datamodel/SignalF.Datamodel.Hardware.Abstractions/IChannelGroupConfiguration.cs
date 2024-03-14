using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface IChannelGroupConfiguration : SignalF.Datamodel.Base.ICoreObject
	{

		#region Properties

		SignalF.Datamodel.Hardware.IChannelConfigurationList Channels { get; }

		SignalF.Datamodel.Hardware.IDeviceBindingConfiguration DeviceBinding { get; set; }

		#endregion Properties


		#region Methods



		#endregion Methods

	}

	public interface IChannelGroupConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IChannelGroupConfiguration visitable);
	}
}

