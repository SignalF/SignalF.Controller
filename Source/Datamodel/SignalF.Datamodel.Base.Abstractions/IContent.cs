using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Base
{

	public enum EContent
	{
		Binary,
		Definition,
		Description,
		Documentation,
		Execution,
		Graphic,
		Implementation,
		Information,
		Library,
		Model,
		Object,
		Text,
	}

	public partial interface IContent
	{

		#region Properties

		EContent Value{get;set;}

		EContent DefaultValue{get;}

		#endregion Properties


		#region Methods

		bool Validate(EContent value);

		#endregion Methods

	}
}

