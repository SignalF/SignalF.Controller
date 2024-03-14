using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial class GpioPinAccessConfiguration : SignalF.Datamodel.Hardware.DeviceConfiguration, SignalF.Datamodel.Hardware.IGpioPinAccessConfiguration
	{
		#region Properties

		#endregion Properties


		#region Interface Implementations

		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as IGpioPinAccessConfigurationVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

