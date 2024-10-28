using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial class SignalConnectionRef : SignalF.Datamodel.Base.Reference, SignalF.Datamodel.Signals.ISignalConnectionRef
	{
		#region Interface Implementations

		public override T Apply<T>(IVisitor<T> visitor)
		{
			var specificVisitor = visitor as ISignalConnectionRefVisitor<T>;
			
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

