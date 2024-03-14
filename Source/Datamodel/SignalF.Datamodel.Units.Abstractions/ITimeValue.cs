using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface ITimeValue : SignalF.Datamodel.Units.IValue
	{
		#region Properties

		Scotec.Math.Units.Time.Units Unit { get; set; }
		Scotec.Math.Units.Time Value { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ITimeValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ITimeValue visitable);
	}
}

