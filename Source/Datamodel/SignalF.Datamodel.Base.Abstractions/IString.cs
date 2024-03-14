using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Base
{
	public partial interface IString
	{

		#region Properties

		System.String Value{get;set;}

		System.String DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(System.String value);

		#endregion Methods

	}
}

