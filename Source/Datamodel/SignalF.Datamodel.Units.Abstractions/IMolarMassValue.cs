using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IMolarMassValue : SignalF.Datamodel.Units.IValue
	{
		#region Properties

		Scotec.Math.Units.MolarMass.Units Unit { get; set; }
		Scotec.Math.Units.MolarMass Value { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IMolarMassValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IMolarMassValue visitable);
	}
}

