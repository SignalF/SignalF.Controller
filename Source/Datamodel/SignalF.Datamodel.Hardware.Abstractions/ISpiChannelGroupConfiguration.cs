using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface ISpiChannelGroupConfiguration : SignalF.Datamodel.Hardware.IChannelGroupConfiguration
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ISpiChannelGroupConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISpiChannelGroupConfiguration visitable);
	}
}

