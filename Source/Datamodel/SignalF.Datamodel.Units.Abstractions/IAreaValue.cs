using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IAreaValue : SignalF.Datamodel.Units.IValue
	{
		#region Properties

		Scotec.Math.Units.Area.Units Unit { get; set; }
		Scotec.Math.Units.Area Value { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IAreaValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IAreaValue visitable);
	}
}

