using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IAccelerationValue : SignalF.Datamodel.Units.IValue
	{
		#region Properties

		Scotec.Math.Units.Acceleration.Units Unit { get; set; }
		Scotec.Math.Units.Acceleration Value { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IAccelerationValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IAccelerationValue visitable);
	}
}

