using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Calculation
{
	public partial interface ICalculatorConfiguration : SignalF.Datamodel.Signals.ISignalProcessorConfiguration
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ICalculatorConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ICalculatorConfiguration visitable);
	}
}

