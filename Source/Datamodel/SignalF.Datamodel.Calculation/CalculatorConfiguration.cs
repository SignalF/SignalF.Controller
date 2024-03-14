using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Calculation
{
	public partial class CalculatorConfiguration : SignalF.Datamodel.Signals.SignalProcessorConfiguration, SignalF.Datamodel.Calculation.ICalculatorConfiguration
	{
		#region Properties

		#endregion Properties


		#region Interface Implementations

		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as ICalculatorConfigurationVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

