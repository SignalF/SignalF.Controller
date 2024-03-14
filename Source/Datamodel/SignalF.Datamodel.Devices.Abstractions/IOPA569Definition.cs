using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface IOPA569Definition : SignalF.Datamodel.Hardware.IDeviceDefinition
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IOPA569DefinitionVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IOPA569Definition visitable);
	}
}

