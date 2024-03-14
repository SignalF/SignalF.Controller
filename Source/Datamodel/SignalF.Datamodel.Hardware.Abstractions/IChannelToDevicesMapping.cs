using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface IChannelToDevicesMapping : IBusinessObject, Scotec.XMLDatabase.IVisitable
	{

		#region Properties

		SignalF.Datamodel.Hardware.IChannelConfiguration Channel { get; set; }

		SignalF.Datamodel.Hardware.IDeviceConfigurationRefList Devices { get; }

		#endregion Properties


		#region Methods



		#endregion Methods

	}

	public interface IChannelToDevicesMappingVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IChannelToDevicesMapping visitable);
	}
}

