using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Workflow
{
	public partial interface IProcessControlDefinition : SignalF.Datamodel.Signals.ISignalProcessorDefinition
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IProcessControlDefinitionVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IProcessControlDefinition visitable);
	}
}

