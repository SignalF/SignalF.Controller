using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface II2cChannelConfiguration : SignalF.Datamodel.Hardware.IChannelConfiguration
	{

		#region Properties

		System.Int32 DeviceAddress { get; set; }

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface II2cChannelConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(II2cChannelConfiguration visitable);
	}
}

