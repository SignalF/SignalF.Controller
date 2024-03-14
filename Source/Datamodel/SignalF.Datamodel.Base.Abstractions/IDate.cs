using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Base
{
	public partial interface IDate
	{

		#region Properties

		System.DateTime Value{get;set;}

		System.DateTime DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(System.DateTime value);

		#endregion Methods

	}
}

