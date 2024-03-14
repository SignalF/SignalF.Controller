using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface ICurrentValue : SignalF.Datamodel.Units.IValue
	{
		#region Properties

		Scotec.Math.Units.Current.Units Unit { get; set; }
		Scotec.Math.Units.Current Value { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ICurrentValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ICurrentValue visitable);
	}
}

