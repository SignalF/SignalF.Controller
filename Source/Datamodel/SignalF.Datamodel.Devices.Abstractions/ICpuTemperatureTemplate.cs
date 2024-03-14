using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface ICpuTemperatureTemplate : SignalF.Datamodel.Hardware.IDeviceTemplate
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ICpuTemperatureTemplateVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ICpuTemperatureTemplate visitable);
	}
}

