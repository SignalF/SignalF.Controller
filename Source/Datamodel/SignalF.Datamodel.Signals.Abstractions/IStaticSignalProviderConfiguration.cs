using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial interface IStaticSignalProviderConfiguration : SignalF.Datamodel.Signals.ISignalProcessorConfiguration
	{

		#region Properties

		SignalF.Datamodel.Signals.ISignalValueList SignalValues { get; }

		#endregion Properties


		#region Methods


		#endregion Methods

	}

	public interface IStaticSignalProviderConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IStaticSignalProviderConfiguration visitable);
	}
}

