using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface ITemperatureUnit : SignalF.Datamodel.Units.IUnit
	{
		#region Properties

		Scotec.Math.Units.Temperature.Units Unit { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ITemperatureUnitVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ITemperatureUnit visitable);
	}
}

