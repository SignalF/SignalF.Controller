using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface IGpioChannelGroupConfigurationRef : SignalF.Datamodel.Base.IReference
	{

	}

	public interface IGpioChannelGroupConfigurationRefVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IGpioChannelGroupConfigurationRef visitable);
	}
}

