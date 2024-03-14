using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface IOneWireChannelGroupConfigurationRef : SignalF.Datamodel.Base.IReference
	{

	}

	public interface IOneWireChannelGroupConfigurationRefVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IOneWireChannelGroupConfigurationRef visitable);
	}
}

