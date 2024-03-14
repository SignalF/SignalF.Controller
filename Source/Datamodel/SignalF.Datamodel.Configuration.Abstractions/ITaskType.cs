using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Configuration
{

	public enum ETaskType
	{
		Init,
		Read,
		Calculate,
		Write,
		Exit,
	}

	public partial interface ITaskType
	{

		#region Properties

		ETaskType Value{get;set;}

		ETaskType DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(ETaskType value);

		#endregion Methods

	}
}

