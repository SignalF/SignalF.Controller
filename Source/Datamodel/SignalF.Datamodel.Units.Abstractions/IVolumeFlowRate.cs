using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IVolumeFlowRate
	{

		#region Properties

		Scotec.Math.Units.VolumeFlowRate.Units Value{get;set;}

		Scotec.Math.Units.VolumeFlowRate.Units DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(Scotec.Math.Units.VolumeFlowRate.Units value);

		#endregion Methods

	}
}

