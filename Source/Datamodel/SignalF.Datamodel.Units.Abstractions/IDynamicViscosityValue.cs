using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IDynamicViscosityValue : SignalF.Datamodel.Units.IValue
	{
		#region Properties

		Scotec.Math.Units.DynamicViscosity.Units Unit { get; set; }
		Scotec.Math.Units.DynamicViscosity Value { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IDynamicViscosityValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IDynamicViscosityValue visitable);
	}
}

