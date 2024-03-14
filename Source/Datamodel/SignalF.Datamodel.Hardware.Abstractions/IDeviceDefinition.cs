using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface IDeviceDefinition : SignalF.Datamodel.Signals.ISignalProcessorDefinition
	{

		#region Properties

		SignalF.Datamodel.Hardware.EConnectionType ConnectionType { get; set; }

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IDeviceDefinitionVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IDeviceDefinition visitable);
	}
}

