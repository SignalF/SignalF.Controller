using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface ISpiDeviceTemplate : SignalF.Datamodel.Hardware.IDeviceTemplate
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ISpiDeviceTemplateVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISpiDeviceTemplate visitable);
	}
}

