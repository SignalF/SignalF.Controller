using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Workflow
{
	public partial class ProcessControlConfiguration : SignalF.Datamodel.Signals.SignalProcessorConfiguration, SignalF.Datamodel.Workflow.IProcessControlConfiguration
	{
		#region Properties

		#endregion Properties


		#region Interface Implementations

		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as IProcessControlConfigurationVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

