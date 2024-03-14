using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface ISpecificWeightValue : SignalF.Datamodel.Units.IValue
	{
		#region Properties

		Scotec.Math.Units.SpecificWeight.Units Unit { get; set; }
		Scotec.Math.Units.SpecificWeight Value { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ISpecificWeightValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISpecificWeightValue visitable);
	}
}

