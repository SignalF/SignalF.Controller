using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Base
{
	public partial interface IByte
	{

		#region Properties

		System.SByte Value{get;set;}

		System.SByte DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(System.SByte value);

		#endregion Methods

	}
}

