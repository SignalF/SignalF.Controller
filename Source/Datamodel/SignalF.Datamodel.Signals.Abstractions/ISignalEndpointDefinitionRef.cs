using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial interface ISignalEndpointDefinitionRef : SignalF.Datamodel.Base.IReference
	{

	}

	public interface ISignalEndpointDefinitionRefVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISignalEndpointDefinitionRef visitable);
	}
}

