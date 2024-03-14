using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IForceValue : SignalF.Datamodel.Units.IValue
	{
		#region Properties

		Scotec.Math.Units.Force.Units Unit { get; set; }
		Scotec.Math.Units.Force Value { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IForceValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IForceValue visitable);
	}
}

