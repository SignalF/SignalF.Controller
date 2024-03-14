using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Workflow
{
	public partial interface IProcessControlConfiguration : SignalF.Datamodel.Signals.ISignalProcessorConfiguration
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IProcessControlConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IProcessControlConfiguration visitable);
	}
}

