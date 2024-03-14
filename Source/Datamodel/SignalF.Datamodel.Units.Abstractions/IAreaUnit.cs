using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IAreaUnit : SignalF.Datamodel.Units.IUnit
	{
		#region Properties

		Scotec.Math.Units.Area.Units Unit { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IAreaUnitVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IAreaUnit visitable);
	}
}

