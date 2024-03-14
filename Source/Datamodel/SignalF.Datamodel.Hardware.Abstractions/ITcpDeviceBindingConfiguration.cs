using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface ITcpDeviceBindingConfiguration : SignalF.Datamodel.Hardware.IDeviceBindingConfiguration
	{

		#region Properties

		System.String IpAddress { get; set; }

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ITcpDeviceBindingConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ITcpDeviceBindingConfiguration visitable);
	}
}

