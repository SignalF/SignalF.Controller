using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Base
{
	public partial interface IDecimal
	{

		#region Properties

		System.Decimal Value{get;set;}

		System.Decimal DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(System.Decimal value);

		#endregion Methods

	}
}

