using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial interface ISignalProcessorTemplate : SignalF.Datamodel.Base.ICoreObject
	{

		#region Properties

		SignalF.Datamodel.Signals.ISignalEndpointDefinitionList SignalSinkDefinitions { get; }

		SignalF.Datamodel.Signals.ISignalEndpointDefinitionList SignalSourceDefinitions { get; }

		#endregion Properties


		#region Methods



		#endregion Methods

	}

	public interface ISignalProcessorTemplateVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISignalProcessorTemplate visitable);
	}
}

