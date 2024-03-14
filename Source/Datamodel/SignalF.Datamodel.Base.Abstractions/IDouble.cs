using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Base
{
	public partial interface IDouble
	{

		#region Properties

		System.Double Value{get;set;}

		System.Double DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(System.Double value);

		#endregion Methods

	}
}

