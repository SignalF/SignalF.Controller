using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial class StaticSignalProviderTemplate : SignalF.Datamodel.Signals.SignalProcessorTemplate, SignalF.Datamodel.Signals.IStaticSignalProviderTemplate
	{
		#region Properties

		#endregion Properties


		#region Interface Implementations

		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as IStaticSignalProviderTemplateVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

