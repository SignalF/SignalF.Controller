using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Base
{
	public partial interface IUInt
	{

		#region Properties

		System.UInt32 Value{get;set;}

		System.UInt32 DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(System.UInt32 value);

		#endregion Methods

	}
}

