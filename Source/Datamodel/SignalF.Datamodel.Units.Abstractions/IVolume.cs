using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IVolume
	{

		#region Properties

		Scotec.Math.Units.Volume.Units Value{get;set;}

		Scotec.Math.Units.Volume.Units DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(Scotec.Math.Units.Volume.Units value);

		#endregion Methods

	}
}

