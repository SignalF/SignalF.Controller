using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Calculation
{
	public partial interface ICalculatorTemplate : SignalF.Datamodel.Signals.ISignalProcessorTemplate
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ICalculatorTemplateVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ICalculatorTemplate visitable);
	}
}

