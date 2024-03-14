using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface INumericUnit : SignalF.Datamodel.Units.IUnit
	{
		#region Properties

		Scotec.Math.Units.Numeric.Units Unit { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface INumericUnitVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(INumericUnit visitable);
	}
}

