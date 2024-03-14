using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Base
{
	public partial interface IFloat
	{

		#region Properties

		System.Single Value{get;set;}

		System.Single DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(System.Single value);

		#endregion Methods

	}
}

