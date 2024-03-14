using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface ILoudnessValue : SignalF.Datamodel.Units.IValue
	{
		#region Properties

		Scotec.Math.Units.Loudness.Units Unit { get; set; }
		Scotec.Math.Units.Loudness Value { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ILoudnessValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ILoudnessValue visitable);
	}
}

