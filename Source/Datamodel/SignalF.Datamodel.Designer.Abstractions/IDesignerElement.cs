using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Designer
{
	public partial interface IDesignerElement : IBusinessObject, Scotec.XMLDatabase.IVisitable
	{

		#region Properties

		System.Guid Id { get; }

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IDesignerElementVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IDesignerElement visitable);
	}
}

