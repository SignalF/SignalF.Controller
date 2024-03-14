using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface IOneWireChannelGroupConfiguration : SignalF.Datamodel.Hardware.IChannelGroupConfiguration
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IOneWireChannelGroupConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IOneWireChannelGroupConfiguration visitable);
	}
}

