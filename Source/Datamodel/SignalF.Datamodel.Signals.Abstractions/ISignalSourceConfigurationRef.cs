using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial interface ISignalSourceConfigurationRef : SignalF.Datamodel.Base.IReference
	{

	}

	public interface ISignalSourceConfigurationRefVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISignalSourceConfigurationRef visitable);
	}
}

