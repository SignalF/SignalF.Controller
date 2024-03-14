using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface ISignalChannelMapping : IBusinessObject, Scotec.XMLDatabase.IVisitable
	{

		#region Properties

		System.Int32 ChannelNumber { get; set; }

		SignalF.Datamodel.Signals.ISignalEndpointDefinition SignalEndpointDefinition { get; set; }

		#endregion Properties


		#region Methods


		#endregion Methods

	}

	public interface ISignalChannelMappingVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISignalChannelMapping visitable);
	}
}

