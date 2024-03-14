using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface IGpioPinAccessTemplate : SignalF.Datamodel.Hardware.IDeviceTemplate
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IGpioPinAccessTemplateVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IGpioPinAccessTemplate visitable);
	}
}

