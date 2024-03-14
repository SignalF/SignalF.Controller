using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Base
{
	public partial interface ICoreObject : IBusinessObject, Scotec.XMLDatabase.IVisitable
	{

		#region Properties

		SignalF.Datamodel.Base.IConfiguration Configuration { get; }

		System.Guid Id { get; }

		System.String Name { get; set; }

		System.String Type { get; set; }

		#endregion Properties


		#region Methods


		#endregion Methods

	}

	public interface ICoreObjectVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ICoreObject visitable);
	}
}

