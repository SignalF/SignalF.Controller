using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IDensityValue : SignalF.Datamodel.Units.IValue
	{
		#region Properties

		Scotec.Math.Units.Density.Units Unit { get; set; }
		Scotec.Math.Units.Density Value { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IDensityValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IDensityValue visitable);
	}
}

