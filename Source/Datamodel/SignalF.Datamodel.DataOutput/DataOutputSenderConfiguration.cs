using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.DataOutput
{
	public partial class DataOutputSenderConfiguration : SignalF.Datamodel.Base.CoreObject, SignalF.Datamodel.DataOutput.IDataOutputSenderConfiguration
	{
		#region Properties

		#endregion Properties


		#region Interface Implementations

		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as IDataOutputSenderConfigurationVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

