using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial interface ISignalSinkConfigurationRef : SignalF.Datamodel.Base.IReference
	{

	}

	public interface ISignalSinkConfigurationRefVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISignalSinkConfigurationRef visitable);
	}
}

