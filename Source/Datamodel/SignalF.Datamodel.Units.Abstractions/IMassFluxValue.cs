using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IMassFluxValue : SignalF.Datamodel.Units.IValue
	{
		#region Properties

		Scotec.Math.Units.MassFlux.Units Unit { get; set; }
		Scotec.Math.Units.MassFlux Value { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IMassFluxValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IMassFluxValue visitable);
	}
}

