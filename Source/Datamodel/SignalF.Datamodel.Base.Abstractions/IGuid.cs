using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Base
{
	public partial interface IGuid
	{

		#region Properties

		System.Guid Value{get;set;}

		System.Guid DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(System.Guid value);

		#endregion Methods

	}
}

