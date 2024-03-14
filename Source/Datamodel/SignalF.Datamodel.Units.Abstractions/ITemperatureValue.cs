using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface ITemperatureValue : SignalF.Datamodel.Units.IValue
	{
		#region Properties

		Scotec.Math.Units.Temperature.Units Unit { get; set; }
		Scotec.Math.Units.Temperature Value { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ITemperatureValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ITemperatureValue visitable);
	}
}

