using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface ICurrentUnit : SignalF.Datamodel.Units.IUnit
	{
		#region Properties

		Scotec.Math.Units.Current.Units Unit { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ICurrentUnitVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ICurrentUnit visitable);
	}
}

