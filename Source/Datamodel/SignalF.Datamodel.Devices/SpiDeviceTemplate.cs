using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial class SpiDeviceTemplate : SignalF.Datamodel.Hardware.DeviceTemplate, SignalF.Datamodel.Devices.ISpiDeviceTemplate
	{
		#region Properties

		#endregion Properties


		#region Interface Implementations

		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as ISpiDeviceTemplateVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

