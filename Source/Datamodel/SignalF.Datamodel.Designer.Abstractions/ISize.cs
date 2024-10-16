using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Designer
{
	public partial interface ISize : IBusinessObject, Scotec.XMLDatabase.IVisitable
	{

		#region Properties

		System.Double Height { get; set; }

		System.Double Width { get; set; }

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface ISizeVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISize visitable);
	}
}

