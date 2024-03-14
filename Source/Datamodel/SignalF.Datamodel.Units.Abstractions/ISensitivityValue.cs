using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface ISensitivityValue : SignalF.Datamodel.Units.IValue
	{
		#region Properties

		Scotec.Math.Units.Sensitivity.Units Unit { get; set; }
		Scotec.Math.Units.Sensitivity Value { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ISensitivityValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISensitivityValue visitable);
	}
}

