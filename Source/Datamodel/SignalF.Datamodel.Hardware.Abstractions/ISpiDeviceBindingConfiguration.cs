using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface ISpiDeviceBindingConfiguration : SignalF.Datamodel.Hardware.IDeviceBindingConfiguration
	{

		#region Properties

		System.Int32 BusId { get; set; }

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ISpiDeviceBindingConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISpiDeviceBindingConfiguration visitable);
	}
}

