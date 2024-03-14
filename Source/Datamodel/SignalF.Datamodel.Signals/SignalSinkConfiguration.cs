using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial class SignalSinkConfiguration : SignalF.Datamodel.Signals.SignalConfiguration, SignalF.Datamodel.Signals.ISignalSinkConfiguration
	{
		#region Properties

		#endregion Properties


		#region Interface Implementations

		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as ISignalSinkConfigurationVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

