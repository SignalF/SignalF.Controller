using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Designer
{
	public partial interface IDesignerConfiguration : IBusinessObject, Scotec.XMLDatabase.IVisitable
	{

		#region Properties

		SignalF.Datamodel.Designer.IDesignerElementList Elements { get; }

		#endregion Properties


		#region Methods


		#endregion Methods

	}

	public interface IDesignerConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IDesignerConfiguration visitable);
	}
}

