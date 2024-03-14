using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface ISpiChannelConfiguration : SignalF.Datamodel.Hardware.IChannelConfiguration
	{

		#region Properties

		System.Int32 ChipSelectLine { get; set; }

		SignalF.Datamodel.Hardware.EGpioPinValue? ChipSelectLineActiveState { get; set; }

		System.Int32? ClockFrequency { get; set; }

		System.Int32? DataBitLength { get; set; }

		SignalF.Datamodel.Hardware.ESpiDataFlow? DataFlow { get; set; }

		SignalF.Datamodel.Hardware.ESpiMode Mode { get; set; }

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ISpiChannelConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISpiChannelConfiguration visitable);
	}
}

