using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface II2cDeviceBindingConfiguration : SignalF.Datamodel.Hardware.IDeviceBindingConfiguration
	{

		#region Properties

		System.Int32 BusId { get; set; }

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface II2cDeviceBindingConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(II2cDeviceBindingConfiguration visitable);
	}
}

