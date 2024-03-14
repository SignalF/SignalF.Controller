using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IMassUnit : SignalF.Datamodel.Units.IUnit
	{
		#region Properties

		Scotec.Math.Units.Mass.Units Unit { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IMassUnitVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IMassUnit visitable);
	}
}

