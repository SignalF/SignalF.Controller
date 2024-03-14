using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial interface ISignalProcessorDefinitionRef : SignalF.Datamodel.Base.IReference
	{

	}

	public interface ISignalProcessorDefinitionRefVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISignalProcessorDefinitionRef visitable);
	}
}

