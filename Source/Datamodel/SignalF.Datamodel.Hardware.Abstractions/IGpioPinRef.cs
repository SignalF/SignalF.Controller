using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface IGpioPinRef : SignalF.Datamodel.Base.IReference
	{

	}

	public interface IGpioPinRefVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IGpioPinRef visitable);
	}
}

