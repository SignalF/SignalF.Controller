using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IAngleUnit : SignalF.Datamodel.Units.IUnit
	{
		#region Properties

		Scotec.Math.Units.Angle.Units Unit { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IAngleUnitVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IAngleUnit visitable);
	}
}

