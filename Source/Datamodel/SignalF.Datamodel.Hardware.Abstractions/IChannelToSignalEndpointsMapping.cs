using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface IChannelToSignalEndpointsMapping : IBusinessObject, Scotec.XMLDatabase.IVisitable
	{

		#region Properties

		SignalF.Datamodel.Hardware.IChannelConfiguration Channel { get; set; }

		SignalF.Datamodel.Signals.ISignalEndpointConfigurationRefList SignalEndpoints { get; }

		#endregion Properties


		#region Methods



		#endregion Methods

	}

	public interface IChannelToSignalEndpointsMappingVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IChannelToSignalEndpointsMapping visitable);
	}
}

