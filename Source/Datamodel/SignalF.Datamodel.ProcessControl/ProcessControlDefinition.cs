using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Workflow
{
	public partial class ProcessControlDefinition : SignalF.Datamodel.Signals.SignalProcessorDefinition, SignalF.Datamodel.Workflow.IProcessControlDefinition
	{
		#region Properties

		#endregion Properties


		#region Interface Implementations

		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as IProcessControlDefinitionVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

