using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface ILengthValue : SignalF.Datamodel.Units.IValue
	{
		#region Properties

		Scotec.Math.Units.Length.Units Unit { get; set; }
		Scotec.Math.Units.Length Value { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ILengthValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ILengthValue visitable);
	}
}

