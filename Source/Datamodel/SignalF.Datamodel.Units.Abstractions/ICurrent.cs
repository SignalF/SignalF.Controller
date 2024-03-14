using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface ICurrent
	{

		#region Properties

		Scotec.Math.Units.Current.Units Value{get;set;}

		Scotec.Math.Units.Current.Units DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(Scotec.Math.Units.Current.Units value);

		#endregion Methods

	}
}

