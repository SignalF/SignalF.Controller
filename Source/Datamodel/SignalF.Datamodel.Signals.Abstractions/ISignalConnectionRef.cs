using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial interface ISignalConnectionRef : SignalF.Datamodel.Base.IReference
	{

	}

	public interface ISignalConnectionRefVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISignalConnectionRef visitable);
	}
}

