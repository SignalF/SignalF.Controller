using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface ITcpChannelGroupConfigurationRef : SignalF.Datamodel.Base.IReference
	{

	}

	public interface ITcpChannelGroupConfigurationRefVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ITcpChannelGroupConfigurationRef visitable);
	}
}

