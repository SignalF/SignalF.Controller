using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface ISpecificVolumeValue : SignalF.Datamodel.Units.IValue
	{
		#region Properties

		Scotec.Math.Units.SpecificVolume.Units Unit { get; set; }
		Scotec.Math.Units.SpecificVolume Value { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ISpecificVolumeValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISpecificVolumeValue visitable);
	}
}

