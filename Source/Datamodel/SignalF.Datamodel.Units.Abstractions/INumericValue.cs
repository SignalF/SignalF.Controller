using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface INumericValue : SignalF.Datamodel.Units.IValue
	{
		#region Properties

		Scotec.Math.Units.Numeric.Units Unit { get; set; }
		Scotec.Math.Units.Numeric Value { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface INumericValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(INumericValue visitable);
	}
}

