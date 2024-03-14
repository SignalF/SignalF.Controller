using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface IGpioDeviceBindingConfiguration : SignalF.Datamodel.Hardware.IDeviceBindingConfiguration
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IGpioDeviceBindingConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IGpioDeviceBindingConfiguration visitable);
	}
}

