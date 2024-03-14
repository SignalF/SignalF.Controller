using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Base
{
	public partial interface IConfiguration : IBusinessObject, Scotec.XMLDatabase.IVisitable
	{

		#region Properties

		System.String Data { get; set; }

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IConfiguration visitable);
	}
}

