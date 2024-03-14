using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Workflow
{
	public partial class ProcessControlTemplate : SignalF.Datamodel.Signals.SignalProcessorTemplate, SignalF.Datamodel.Workflow.IProcessControlTemplate
	{
		#region Properties

		#endregion Properties


		#region Interface Implementations

		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as IProcessControlTemplateVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

