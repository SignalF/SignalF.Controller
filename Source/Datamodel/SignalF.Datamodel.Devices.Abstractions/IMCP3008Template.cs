using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface IMCP3008Template : SignalF.Datamodel.Hardware.IDeviceTemplate
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IMCP3008TemplateVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IMCP3008Template visitable);
	}
}

