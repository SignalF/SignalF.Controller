using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface ISI7021Template : SignalF.Datamodel.Hardware.IDeviceTemplate
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ISI7021TemplateVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISI7021Template visitable);
	}
}

