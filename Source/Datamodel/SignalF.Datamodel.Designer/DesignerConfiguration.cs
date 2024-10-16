using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Designer
{
	public partial class DesignerConfiguration : BusinessObject, SignalF.Datamodel.Designer.IDesignerConfiguration
	{
		#region Properties

		
		SignalF.Datamodel.Designer.IDesignerElementList IDesignerConfiguration.Elements
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Designer.IDesignerElementList)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("Elements"));
				}
				catch(Scotec.XMLDatabase.DataException e)
				{
					throw new BusinessException((EBusinessError)e.DataError, e.Message, e);
				}
				catch(Exception e)
				{
					throw new BusinessException(EBusinessError.Document, "Caught unhandled exception.", e);
				}
			}
		}
		#endregion Properties


		#region Interface Implementations



		public virtual TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as IDesignerConfigurationVisitor<TResult>;
			if (specificVisitor != null)
				return specificVisitor.Visit(this);

			var objectVisitor = visitor as IObjectVisitor<TResult>;
			
			if (objectVisitor != null)
				return objectVisitor.Visit(this);
			throw new NotSupportedException("Visitor of type " + visitor.GetType().FullName + " does not support visiting objects of type " + GetType().FullName + '.');
		}

		#endregion Interface Implementations

	}
}

