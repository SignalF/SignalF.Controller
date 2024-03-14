using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial interface IStaticSignalProviderDefinition : SignalF.Datamodel.Signals.ISignalProcessorDefinition
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IStaticSignalProviderDefinitionVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IStaticSignalProviderDefinition visitable);
	}
}

