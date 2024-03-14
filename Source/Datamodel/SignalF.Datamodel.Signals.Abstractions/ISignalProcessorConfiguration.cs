using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial interface ISignalProcessorConfiguration : SignalF.Datamodel.Base.ICoreObject
	{

		#region Properties

		SignalF.Datamodel.Signals.ISignalProcessorDefinition Definition { get; set; }

		SignalF.Datamodel.Signals.ISignalSinkConfigurationList SignalSinks { get; }

		SignalF.Datamodel.Signals.ISignalSourceConfigurationList SignalSources { get; }

		#endregion Properties


		#region Methods




		#endregion Methods

	}

	public interface ISignalProcessorConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISignalProcessorConfiguration visitable);
	}
}

