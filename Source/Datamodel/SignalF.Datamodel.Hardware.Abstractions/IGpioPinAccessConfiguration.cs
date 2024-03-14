using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface IGpioPinAccessConfiguration : SignalF.Datamodel.Hardware.IDeviceConfiguration
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IGpioPinAccessConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IGpioPinAccessConfiguration visitable);
	}
}

