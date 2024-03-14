using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface ICpuTemperatureDefinition : SignalF.Datamodel.Hardware.IDeviceDefinition
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ICpuTemperatureDefinitionVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ICpuTemperatureDefinition visitable);
	}
}

