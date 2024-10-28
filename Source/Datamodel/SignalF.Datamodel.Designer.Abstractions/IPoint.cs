using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Designer
{
	public partial interface IPoint : IBusinessObject, Scotec.XMLDatabase.IVisitable
	{

		#region Properties

		System.Double X { get; set; }

		System.Double Y { get; set; }

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IPointVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IPoint visitable);
	}
}

