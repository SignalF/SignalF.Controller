using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial class OneWireChannelGroupConfiguration : SignalF.Datamodel.Hardware.ChannelGroupConfiguration, SignalF.Datamodel.Hardware.IOneWireChannelGroupConfiguration
	{
		#region Properties

		#endregion Properties


		#region Interface Implementations

		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as IOneWireChannelGroupConfigurationVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

