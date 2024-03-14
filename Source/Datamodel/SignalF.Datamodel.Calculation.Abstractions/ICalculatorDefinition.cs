using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Calculation
{
	public partial interface ICalculatorDefinition : SignalF.Datamodel.Signals.ISignalProcessorDefinition
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ICalculatorDefinitionVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ICalculatorDefinition visitable);
	}
}

