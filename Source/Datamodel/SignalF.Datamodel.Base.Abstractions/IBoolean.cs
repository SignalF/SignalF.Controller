using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Base
{
	public partial interface IBoolean
	{

		#region Properties

		System.Boolean Value{get;set;}

		System.Boolean DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(System.Boolean value);

		#endregion Methods

	}
}

