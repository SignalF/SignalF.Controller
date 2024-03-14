using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface ISI7021Definition : SignalF.Datamodel.Hardware.IDeviceDefinition
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ISI7021DefinitionVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISI7021Definition visitable);
	}
}

