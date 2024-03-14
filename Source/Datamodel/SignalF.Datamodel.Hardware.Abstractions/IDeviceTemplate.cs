using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface IDeviceTemplate : SignalF.Datamodel.Signals.ISignalProcessorTemplate
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IDeviceTemplateVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IDeviceTemplate visitable);
	}
}

