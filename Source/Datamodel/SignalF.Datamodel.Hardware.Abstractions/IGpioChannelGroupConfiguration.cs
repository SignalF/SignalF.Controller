using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface IGpioChannelGroupConfiguration : SignalF.Datamodel.Hardware.IChannelGroupConfiguration
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IGpioChannelGroupConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IGpioChannelGroupConfiguration visitable);
	}
}

