using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public abstract partial class ChannelConfiguration : SignalF.Datamodel.Base.CoreObject, SignalF.Datamodel.Hardware.IChannelConfiguration
	{
		#region Properties

		#endregion Properties


		#region Interface Implementations

		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as IChannelConfigurationVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

