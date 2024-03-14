using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface ILengthUnit : SignalF.Datamodel.Units.IUnit
	{
		#region Properties

		Scotec.Math.Units.Length.Units Unit { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ILengthUnitVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ILengthUnit visitable);
	}
}

