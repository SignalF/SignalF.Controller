using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface IChannelConfigurationRef : SignalF.Datamodel.Base.IReference
	{

	}

	public interface IChannelConfigurationRefVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IChannelConfigurationRef visitable);
	}
}

