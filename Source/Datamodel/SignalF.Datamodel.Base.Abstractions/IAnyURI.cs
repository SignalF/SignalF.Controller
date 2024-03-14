using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Base
{
	public partial interface IAnyURI
	{

		#region Properties

		System.Uri Value{get;set;}

		System.Uri DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(System.Uri value);

		#endregion Methods

	}
}

