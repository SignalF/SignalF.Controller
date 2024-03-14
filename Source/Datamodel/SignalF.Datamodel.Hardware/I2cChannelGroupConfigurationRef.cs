using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial class I2cChannelGroupConfigurationRef : SignalF.Datamodel.Base.Reference, SignalF.Datamodel.Hardware.II2cChannelGroupConfigurationRef
	{
		#region Interface Implementations

		public override T Apply<T>(IVisitor<T> visitor)
		{
			var specificVisitor = visitor as II2cChannelGroupConfigurationRefVisitor<T>;
			
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

