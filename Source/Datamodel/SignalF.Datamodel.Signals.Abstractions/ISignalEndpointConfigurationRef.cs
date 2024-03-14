using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial interface ISignalEndpointConfigurationRef : SignalF.Datamodel.Base.IReference
	{

	}

	public interface ISignalEndpointConfigurationRefVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISignalEndpointConfigurationRef visitable);
	}
}

