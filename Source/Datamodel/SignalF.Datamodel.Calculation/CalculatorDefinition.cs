using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Calculation
{
	public partial class CalculatorDefinition : SignalF.Datamodel.Signals.SignalProcessorDefinition, SignalF.Datamodel.Calculation.ICalculatorDefinition
	{
		#region Properties

		#endregion Properties


		#region Interface Implementations

		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as ICalculatorDefinitionVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

