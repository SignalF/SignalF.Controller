using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial interface ISignalProcessorDefinition : SignalF.Datamodel.Base.ICoreObject
	{

		#region Properties

		SignalF.Datamodel.Signals.ISignalEndpointDefinitionList SignalSinkDefinitions { get; }

		SignalF.Datamodel.Signals.ISignalEndpointDefinitionList SignalSourceDefinitions { get; }

		SignalF.Datamodel.Signals.ISignalProcessorTemplate Template { get; set; }

		#endregion Properties


		#region Methods




		#endregion Methods

	}

	public interface ISignalProcessorDefinitionVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISignalProcessorDefinition visitable);
	}
}

