using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface ITimeUnit : SignalF.Datamodel.Units.IUnit
	{
		#region Properties

		Scotec.Math.Units.Time.Units Unit { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ITimeUnitVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ITimeUnit visitable);
	}
}

