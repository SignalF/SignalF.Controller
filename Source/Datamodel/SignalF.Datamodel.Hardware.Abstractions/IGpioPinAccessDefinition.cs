using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface IGpioPinAccessDefinition : SignalF.Datamodel.Hardware.IDeviceDefinition
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IGpioPinAccessDefinitionVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IGpioPinAccessDefinition visitable);
	}
}

