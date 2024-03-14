using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IVolumeValue : SignalF.Datamodel.Units.IValue
	{
		#region Properties

		Scotec.Math.Units.Volume.Units Unit { get; set; }
		Scotec.Math.Units.Volume Value { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IVolumeValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IVolumeValue visitable);
	}
}

