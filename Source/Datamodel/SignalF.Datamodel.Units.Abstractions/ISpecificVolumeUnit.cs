using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface ISpecificVolumeUnit : SignalF.Datamodel.Units.IUnit
	{
		#region Properties

		Scotec.Math.Units.SpecificVolume.Units Unit { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ISpecificVolumeUnitVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISpecificVolumeUnit visitable);
	}
}

