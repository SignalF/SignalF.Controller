using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface ITcpChannelGroupConfiguration : SignalF.Datamodel.Hardware.IChannelGroupConfiguration
	{

		#region Properties

		System.String IpAddress { get; set; }

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ITcpChannelGroupConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ITcpChannelGroupConfiguration visitable);
	}
}

