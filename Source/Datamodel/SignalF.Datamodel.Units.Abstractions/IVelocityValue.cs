using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IVelocityValue : SignalF.Datamodel.Units.IValue
	{
		#region Properties

		Scotec.Math.Units.Velocity.Units Unit { get; set; }
		Scotec.Math.Units.Velocity Value { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IVelocityValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IVelocityValue visitable);
	}
}

