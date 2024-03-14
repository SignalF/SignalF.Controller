using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface ISensitivity
	{

		#region Properties

		Scotec.Math.Units.Sensitivity.Units Value{get;set;}

		Scotec.Math.Units.Sensitivity.Units DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(Scotec.Math.Units.Sensitivity.Units value);

		#endregion Methods

	}
}

