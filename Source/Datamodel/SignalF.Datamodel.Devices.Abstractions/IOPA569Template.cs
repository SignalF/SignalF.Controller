using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface IOPA569Template : SignalF.Datamodel.Hardware.IDeviceTemplate
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IOPA569TemplateVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IOPA569Template visitable);
	}
}

