using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface ILength
	{

		#region Properties

		Scotec.Math.Units.Length.Units Value{get;set;}

		Scotec.Math.Units.Length.Units DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(Scotec.Math.Units.Length.Units value);

		#endregion Methods

	}
}

