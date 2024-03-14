using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface II2cChannelGroupConfigurationRef : SignalF.Datamodel.Base.IReference
	{

	}

	public interface II2cChannelGroupConfigurationRefVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(II2cChannelGroupConfigurationRef visitable);
	}
}

