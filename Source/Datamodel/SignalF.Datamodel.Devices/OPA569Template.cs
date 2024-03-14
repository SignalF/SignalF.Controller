using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial class OPA569Template : SignalF.Datamodel.Hardware.DeviceTemplate, SignalF.Datamodel.Devices.IOPA569Template
	{
		#region Properties

		#endregion Properties


		#region Interface Implementations

		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as IOPA569TemplateVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

