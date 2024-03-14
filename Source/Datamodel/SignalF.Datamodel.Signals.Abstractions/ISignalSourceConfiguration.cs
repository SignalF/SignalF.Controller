using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial interface ISignalSourceConfiguration : SignalF.Datamodel.Signals.ISignalConfiguration
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ISignalSourceConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISignalSourceConfiguration visitable);
	}
}

