using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface ISensitivityUnit : SignalF.Datamodel.Units.IUnit
	{
		#region Properties

		Scotec.Math.Units.Sensitivity.Units Unit { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ISensitivityUnitVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISensitivityUnit visitable);
	}
}

