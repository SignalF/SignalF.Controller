using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface IMCP4821Template : SignalF.Datamodel.Hardware.IDeviceTemplate
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IMCP4821TemplateVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IMCP4821Template visitable);
	}
}

