using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface IDeviceBindingConfiguration : SignalF.Datamodel.Base.ICoreObject
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IDeviceBindingConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IDeviceBindingConfiguration visitable);
	}
}

