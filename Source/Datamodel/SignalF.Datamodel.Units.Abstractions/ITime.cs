using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface ITime
	{

		#region Properties

		Scotec.Math.Units.Time.Units Value{get;set;}

		Scotec.Math.Units.Time.Units DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(Scotec.Math.Units.Time.Units value);

		#endregion Methods

	}
}

