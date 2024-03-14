using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface IMCP4821Definition : SignalF.Datamodel.Hardware.IDeviceDefinition
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IMCP4821DefinitionVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IMCP4821Definition visitable);
	}
}

