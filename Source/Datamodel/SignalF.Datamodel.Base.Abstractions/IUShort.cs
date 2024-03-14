using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Base
{
	public partial interface IUShort
	{

		#region Properties

		System.UInt16 Value{get;set;}

		System.UInt16 DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(System.UInt16 value);

		#endregion Methods

	}
}

