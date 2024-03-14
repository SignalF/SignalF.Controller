using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Base
{
	public partial interface IReference : IBusinessObject, Scotec.XMLDatabase.IVisitable
	{

		#region Properties

		System.Guid? IdRef { get; set; }

		System.String Location { get; set; }

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IReferenceVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IReference visitable);
	}
}

