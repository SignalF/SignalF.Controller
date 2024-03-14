using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface IOneWireDeviceBindingConfiguration : SignalF.Datamodel.Hardware.IDeviceBindingConfiguration
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IOneWireDeviceBindingConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IOneWireDeviceBindingConfiguration visitable);
	}
}

