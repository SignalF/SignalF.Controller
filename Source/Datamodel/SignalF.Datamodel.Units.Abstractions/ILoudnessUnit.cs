using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface ILoudnessUnit : SignalF.Datamodel.Units.IUnit
	{
		#region Properties

		Scotec.Math.Units.Loudness.Units Unit { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ILoudnessUnitVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ILoudnessUnit visitable);
	}
}

