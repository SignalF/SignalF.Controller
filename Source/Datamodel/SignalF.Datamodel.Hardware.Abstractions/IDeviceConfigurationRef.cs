using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface IDeviceConfigurationRef : SignalF.Datamodel.Base.IReference
	{

	}

	public interface IDeviceConfigurationRefVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IDeviceConfigurationRef visitable);
	}
}

