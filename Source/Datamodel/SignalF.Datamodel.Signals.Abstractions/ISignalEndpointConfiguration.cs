using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial interface ISignalEndpointConfiguration : IBusinessObject, Scotec.XMLDatabase.IVisitable
	{

		#region Properties

		SignalF.Datamodel.Signals.ISignalEndpointDefinition Definition { get; set; }

		System.Guid Id { get; }

		System.String Name { get; set; }

		#endregion Properties


		#region Methods


		#endregion Methods

	}

	public interface ISignalEndpointConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISignalEndpointConfiguration visitable);
	}
}

