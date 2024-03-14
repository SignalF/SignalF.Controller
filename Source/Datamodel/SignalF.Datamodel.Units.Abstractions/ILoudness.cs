using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface ILoudness
	{

		#region Properties

		Scotec.Math.Units.Loudness.Units Value{get;set;}

		Scotec.Math.Units.Loudness.Units DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(Scotec.Math.Units.Loudness.Units value);

		#endregion Methods

	}
}

