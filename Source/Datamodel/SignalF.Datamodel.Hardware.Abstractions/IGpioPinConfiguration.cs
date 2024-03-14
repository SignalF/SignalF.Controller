using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface IGpioPinConfiguration : IBusinessObject, Scotec.XMLDatabase.IVisitable
	{

		#region Properties

		SignalF.Datamodel.Hardware.EGpioPinDriveMode DriveMode { get; set; }

		System.Guid Id { get; }

		SignalF.Datamodel.Hardware.EGpioPinValue? InitialValue { get; set; }

		SignalF.Datamodel.Hardware.EGpioSharingMode SharingMode { get; set; }

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IGpioPinConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IGpioPinConfiguration visitable);
	}
}

