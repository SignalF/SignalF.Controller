using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial class GpioPinRef : SignalF.Datamodel.Base.Reference, SignalF.Datamodel.Hardware.IGpioPinRef
	{
		#region Interface Implementations

		public override T Apply<T>(IVisitor<T> visitor)
		{
			var specificVisitor = visitor as IGpioPinRefVisitor<T>;
			
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

