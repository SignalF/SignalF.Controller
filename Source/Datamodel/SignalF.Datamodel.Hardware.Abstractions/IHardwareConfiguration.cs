using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface IHardwareConfiguration : IBusinessObject, Scotec.XMLDatabase.IVisitable
	{

		#region Properties

		SignalF.Datamodel.Hardware.IChannelGroupConfigurationList ChannelGroups { get; }

		#endregion Properties


		#region Methods


		#endregion Methods

	}

	public interface IHardwareConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IHardwareConfiguration visitable);
	}
}

