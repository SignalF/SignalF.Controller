using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.DataOutput
{
	public partial class DataOutputSenderConfigurationRef : SignalF.Datamodel.Base.Reference, SignalF.Datamodel.DataOutput.IDataOutputSenderConfigurationRef
	{
		#region Interface Implementations

		public override T Apply<T>(IVisitor<T> visitor)
		{
			var specificVisitor = visitor as IDataOutputSenderConfigurationRefVisitor<T>;
			
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

