using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface IGenericDeviceTemplate : SignalF.Datamodel.Hardware.IDeviceTemplate
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IGenericDeviceTemplateVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IGenericDeviceTemplate visitable);
	}
}

