using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface II2cDeviceTemplate : SignalF.Datamodel.Hardware.IDeviceTemplate
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface II2cDeviceTemplateVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(II2cDeviceTemplate visitable);
	}
}

