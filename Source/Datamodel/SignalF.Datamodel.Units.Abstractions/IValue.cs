using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IValue : IBusinessObject, Scotec.XMLDatabase.IVisitable
	{
		#region Properties

		System.Double? SIValue { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IValue visitable);
	}
}

