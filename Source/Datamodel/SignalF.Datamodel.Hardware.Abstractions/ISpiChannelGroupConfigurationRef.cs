using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface ISpiChannelGroupConfigurationRef : SignalF.Datamodel.Base.IReference
	{

	}

	public interface ISpiChannelGroupConfigurationRefVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISpiChannelGroupConfigurationRef visitable);
	}
}

