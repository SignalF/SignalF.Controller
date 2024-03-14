using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface INumeric
	{

		#region Properties

		Scotec.Math.Units.Numeric.Units Value{get;set;}

		Scotec.Math.Units.Numeric.Units DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(Scotec.Math.Units.Numeric.Units value);

		#endregion Methods

	}
}

