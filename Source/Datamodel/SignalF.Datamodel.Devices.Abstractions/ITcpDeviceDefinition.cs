using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface ITcpDeviceDefinition : SignalF.Datamodel.Hardware.IDeviceDefinition
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ITcpDeviceDefinitionVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ITcpDeviceDefinition visitable);
	}
}

