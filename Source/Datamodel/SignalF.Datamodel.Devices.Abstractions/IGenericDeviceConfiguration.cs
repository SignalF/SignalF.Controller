using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface IGenericDeviceConfiguration : SignalF.Datamodel.Hardware.IDeviceConfiguration
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IGenericDeviceConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IGenericDeviceConfiguration visitable);
	}
}

