using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IArea
	{

		#region Properties

		Scotec.Math.Units.Area.Units Value{get;set;}

		Scotec.Math.Units.Area.Units DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(Scotec.Math.Units.Area.Units value);

		#endregion Methods

	}
}

