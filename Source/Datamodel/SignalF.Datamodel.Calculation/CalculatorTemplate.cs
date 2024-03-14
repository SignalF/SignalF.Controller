using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Calculation
{
	public partial class CalculatorTemplate : SignalF.Datamodel.Signals.SignalProcessorTemplate, SignalF.Datamodel.Calculation.ICalculatorTemplate
	{
		#region Properties

		#endregion Properties


		#region Interface Implementations

		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as ICalculatorTemplateVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

