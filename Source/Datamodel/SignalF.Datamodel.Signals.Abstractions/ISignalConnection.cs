using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial interface ISignalConnection : IBusinessObject, Scotec.XMLDatabase.IVisitable
	{

		#region Properties

		SignalF.Datamodel.Signals.ISignalSinkConfiguration SignalSink { get; set; }

		SignalF.Datamodel.Signals.ISignalSourceConfiguration SignalSource { get; set; }

		#endregion Properties


		#region Methods



		#endregion Methods

	}

	public interface ISignalConnectionVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISignalConnection visitable);
	}
}

