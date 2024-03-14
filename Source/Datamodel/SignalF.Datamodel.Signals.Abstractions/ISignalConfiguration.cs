using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial interface ISignalConfiguration : SignalF.Datamodel.Signals.ISignalEndpointConfiguration
	{

		#region Properties

		SignalF.Datamodel.Units.IUnit Unit { get; }

		#endregion Properties


		#region Methods

		bool HasUnit();
		TUnit CreateUnit<TUnit>() where TUnit : SignalF.Datamodel.Units.IUnit;
		void DeleteUnit();

		#endregion Methods

	}

	public interface ISignalConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISignalConfiguration visitable);
	}
}

