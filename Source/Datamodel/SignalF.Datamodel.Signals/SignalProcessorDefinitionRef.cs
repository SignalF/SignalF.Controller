using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial class SignalProcessorDefinitionRef : SignalF.Datamodel.Base.Reference, SignalF.Datamodel.Signals.ISignalProcessorDefinitionRef
	{
		#region Interface Implementations

		public override T Apply<T>(IVisitor<T> visitor)
		{
			var specificVisitor = visitor as ISignalProcessorDefinitionRefVisitor<T>;
			
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

