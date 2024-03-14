using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Base
{
	public partial interface IULong
	{

		#region Properties

		System.UInt64 Value{get;set;}

		System.UInt64 DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(System.UInt64 value);

		#endregion Methods

	}
}

