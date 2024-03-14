using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial class TcpChannelGroupConfigurationRef : SignalF.Datamodel.Base.Reference, SignalF.Datamodel.Hardware.ITcpChannelGroupConfigurationRef
	{
		#region Interface Implementations

		public override T Apply<T>(IVisitor<T> visitor)
		{
			var specificVisitor = visitor as ITcpChannelGroupConfigurationRefVisitor<T>;
			
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

