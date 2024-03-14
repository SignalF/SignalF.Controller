using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Workflow
{
	public partial interface IProcessControlTemplate : SignalF.Datamodel.Signals.ISignalProcessorTemplate
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IProcessControlTemplateVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IProcessControlTemplate visitable);
	}
}

