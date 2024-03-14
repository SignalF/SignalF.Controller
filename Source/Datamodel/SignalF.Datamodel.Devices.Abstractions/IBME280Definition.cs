using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface IBME280Definition : SignalF.Datamodel.Hardware.IDeviceDefinition
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IBME280DefinitionVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IBME280Definition visitable);
	}
}

