using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface ISpiDeviceDefinition : SignalF.Datamodel.Hardware.IDeviceDefinition
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ISpiDeviceDefinitionVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISpiDeviceDefinition visitable);
	}
}

