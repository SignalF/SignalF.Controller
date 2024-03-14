using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface ITcpChannelConfiguration : SignalF.Datamodel.Hardware.IChannelConfiguration
	{

		#region Properties

		System.Int32 Port { get; set; }

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ITcpChannelConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ITcpChannelConfiguration visitable);
	}
}

