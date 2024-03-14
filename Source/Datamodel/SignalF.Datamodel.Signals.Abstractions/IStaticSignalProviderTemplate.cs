using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial interface IStaticSignalProviderTemplate : SignalF.Datamodel.Signals.ISignalProcessorTemplate
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IStaticSignalProviderTemplateVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IStaticSignalProviderTemplate visitable);
	}
}

