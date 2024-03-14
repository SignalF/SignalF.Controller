using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial interface ISignalValue : IBusinessObject, Scotec.XMLDatabase.IVisitable
	{

		#region Properties

		SignalF.Datamodel.Signals.ISignalSourceConfiguration SignalSource { get; set; }

		SignalF.Datamodel.Signals.EUnitType UnitType { get; set; }

		SignalF.Datamodel.Units.IValue Value { get; }

		#endregion Properties


		#region Methods


		bool HasValue();
		TValue CreateValue<TValue>() where TValue : SignalF.Datamodel.Units.IValue;
		void DeleteValue();

		#endregion Methods

	}

	public interface ISignalValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISignalValue visitable);
	}
}

