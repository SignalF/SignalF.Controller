using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IUnit : IBusinessObject, Scotec.XMLDatabase.IVisitable
	{
		#region Properties


		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IUnitVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IUnit visitable);
	}
}

