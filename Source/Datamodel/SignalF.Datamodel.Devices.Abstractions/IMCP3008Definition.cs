using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface IMCP3008Definition : SignalF.Datamodel.Hardware.IDeviceDefinition
	{

		#region Properties

		SignalF.Datamodel.Hardware.ISignalChannelMappingList SignalChannelMappings { get; }

		#endregion Properties


		#region Methods


		#endregion Methods

	}

	public interface IMCP3008DefinitionVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IMCP3008Definition visitable);
	}
}

