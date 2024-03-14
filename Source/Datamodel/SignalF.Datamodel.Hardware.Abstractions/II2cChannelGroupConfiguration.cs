using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface II2cChannelGroupConfiguration : SignalF.Datamodel.Hardware.IChannelGroupConfiguration
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface II2cChannelGroupConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(II2cChannelGroupConfiguration visitable);
	}
}

