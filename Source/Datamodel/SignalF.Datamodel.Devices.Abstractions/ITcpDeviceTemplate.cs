using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface ITcpDeviceTemplate : SignalF.Datamodel.Hardware.IDeviceTemplate
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ITcpDeviceTemplateVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ITcpDeviceTemplate visitable);
	}
}

