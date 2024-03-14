using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Base
{
	public partial interface ILong
	{

		#region Properties

		System.Int64 Value{get;set;}

		System.Int64 DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(System.Int64 value);

		#endregion Methods

	}
}

