using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial interface ISignalProcessorConfigurationRef : SignalF.Datamodel.Base.IReference
	{

	}

	public interface ISignalProcessorConfigurationRefVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISignalProcessorConfigurationRef visitable);
	}
}

