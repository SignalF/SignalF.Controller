using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Base
{
	public partial interface IInt
	{

		#region Properties

		System.Int32 Value{get;set;}

		System.Int32 DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(System.Int32 value);

		#endregion Methods

	}
}

