using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface II2cDeviceDefinition : SignalF.Datamodel.Hardware.IDeviceDefinition
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface II2cDeviceDefinitionVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(II2cDeviceDefinition visitable);
	}
}

