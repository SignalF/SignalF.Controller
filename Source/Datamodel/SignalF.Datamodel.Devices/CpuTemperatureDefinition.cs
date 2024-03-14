using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial class CpuTemperatureDefinition : SignalF.Datamodel.Hardware.DeviceDefinition, SignalF.Datamodel.Devices.ICpuTemperatureDefinition
	{
		#region Properties

		#endregion Properties


		#region Interface Implementations

		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as ICpuTemperatureDefinitionVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

