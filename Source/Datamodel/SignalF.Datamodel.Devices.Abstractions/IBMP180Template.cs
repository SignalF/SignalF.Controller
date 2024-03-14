using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial interface IBMP180Template : SignalF.Datamodel.Hardware.IDeviceTemplate
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IBMP180TemplateVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IBMP180Template visitable);
	}
}

