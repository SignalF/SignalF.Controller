using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface IDeviceBindingConfigurationRef : SignalF.Datamodel.Base.IReference
	{

	}

	public interface IDeviceBindingConfigurationRefVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IDeviceBindingConfigurationRef visitable);
	}
}

