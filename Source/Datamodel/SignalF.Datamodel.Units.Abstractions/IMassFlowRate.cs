using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IMassFlowRate
	{

		#region Properties

		Scotec.Math.Units.MassFlowRate.Units Value{get;set;}

		Scotec.Math.Units.MassFlowRate.Units DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(Scotec.Math.Units.MassFlowRate.Units value);

		#endregion Methods

	}
}

