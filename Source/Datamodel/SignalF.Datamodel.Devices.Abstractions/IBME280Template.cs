using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface IBME280Template : SignalF.Datamodel.Hardware.IDeviceTemplate
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IBME280TemplateVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IBME280Template visitable);
	}
}

