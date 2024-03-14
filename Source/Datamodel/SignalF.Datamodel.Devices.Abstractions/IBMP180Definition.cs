using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface IBMP180Definition : SignalF.Datamodel.Hardware.IDeviceDefinition
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IBMP180DefinitionVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IBMP180Definition visitable);
	}
}

