using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial class I2cDeviceTemplate : SignalF.Datamodel.Hardware.DeviceTemplate, SignalF.Datamodel.Devices.II2cDeviceTemplate
	{
		#region Properties

		#endregion Properties


		#region Interface Implementations

		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as II2cDeviceTemplateVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

