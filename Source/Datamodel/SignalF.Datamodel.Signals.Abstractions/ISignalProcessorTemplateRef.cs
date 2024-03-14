using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial interface ISignalProcessorTemplateRef : SignalF.Datamodel.Base.IReference
	{

	}

	public interface ISignalProcessorTemplateRefVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISignalProcessorTemplateRef visitable);
	}
}

