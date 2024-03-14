using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface ISpecificEnthalpyValue : SignalF.Datamodel.Units.IValue
	{
		#region Properties

		Scotec.Math.Units.SpecificEnthalpy.Units Unit { get; set; }
		Scotec.Math.Units.SpecificEnthalpy Value { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ISpecificEnthalpyValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISpecificEnthalpyValue visitable);
	}
}

