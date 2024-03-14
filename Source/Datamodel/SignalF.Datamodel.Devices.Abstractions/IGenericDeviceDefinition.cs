using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface IGenericDeviceDefinition : SignalF.Datamodel.Hardware.IDeviceDefinition
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IGenericDeviceDefinitionVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IGenericDeviceDefinition visitable);
	}
}

