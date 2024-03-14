using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IVolumeUnit : SignalF.Datamodel.Units.IUnit
	{
		#region Properties

		Scotec.Math.Units.Volume.Units Unit { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IVolumeUnitVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IVolumeUnit visitable);
	}
}

