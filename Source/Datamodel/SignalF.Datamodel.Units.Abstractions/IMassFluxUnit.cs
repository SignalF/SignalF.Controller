using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IMassFluxUnit : SignalF.Datamodel.Units.IUnit
	{
		#region Properties

		Scotec.Math.Units.MassFlux.Units Unit { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IMassFluxUnitVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IMassFluxUnit visitable);
	}
}

