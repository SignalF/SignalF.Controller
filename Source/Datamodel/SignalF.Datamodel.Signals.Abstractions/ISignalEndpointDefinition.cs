using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial interface ISignalEndpointDefinition : IBusinessObject, Scotec.XMLDatabase.IVisitable
	{

		#region Properties

		System.Guid Id { get; }

		System.String Name { get; set; }

		SignalF.Datamodel.Signals.EUnitType UnitType { get; set; }

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ISignalEndpointDefinitionVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISignalEndpointDefinition visitable);
	}
}

