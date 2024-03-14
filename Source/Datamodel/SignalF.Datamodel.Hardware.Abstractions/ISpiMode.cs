using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{

	public enum ESpiMode
	{
		Mode0,
		Mode1,
		Mode2,
		Mode3,
	}

	public partial interface ISpiMode
	{

		#region Properties

		ESpiMode Value{get;set;}

		ESpiMode DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(ESpiMode value);

		#endregion Methods

	}
}

