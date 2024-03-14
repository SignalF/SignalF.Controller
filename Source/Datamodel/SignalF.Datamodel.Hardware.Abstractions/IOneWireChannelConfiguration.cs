using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface IOneWireChannelConfiguration : SignalF.Datamodel.Hardware.IChannelConfiguration
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IOneWireChannelConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IOneWireChannelConfiguration visitable);
	}
}

