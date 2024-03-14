using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface ICpuTemperatureConfiguration : SignalF.Datamodel.Hardware.IDeviceConfiguration
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ICpuTemperatureConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ICpuTemperatureConfiguration visitable);
	}
}

