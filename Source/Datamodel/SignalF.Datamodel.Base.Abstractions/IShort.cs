using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Base
{
	public partial interface IShort
	{

		#region Properties

		System.Int16 Value{get;set;}

		System.Int16 DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(System.Int16 value);

		#endregion Methods

	}
}

