using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Designer
{
	public abstract partial class Position : BusinessObject, SignalF.Datamodel.Designer.IPosition
	{
		#region Properties

		
		private const string X_PROPERTY_NAME = "X";		
		System.Double IPosition.X
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Base.IDouble)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(X_PROPERTY_NAME))).Value;
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
			set
			{
				try
				{
					var attribute = (SignalF.Datamodel.Base.IDouble)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(X_PROPERTY_NAME));
					
					if(attribute.Value == (System.Double)value)
						return;
					
					attribute.Value = (System.Double)value;
					AddModifiedProperty(X_PROPERTY_NAME);
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
		
		private const string Y_PROPERTY_NAME = "Y";		
		System.Double IPosition.Y
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Base.IDouble)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(Y_PROPERTY_NAME))).Value;
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
			set
			{
				try
				{
					var attribute = (SignalF.Datamodel.Base.IDouble)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(Y_PROPERTY_NAME));
					
					if(attribute.Value == (System.Double)value)
						return;
					
					attribute.Value = (System.Double)value;
					AddModifiedProperty(Y_PROPERTY_NAME);
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
			var specificVisitor = visitor as IPositionVisitor<TResult>;
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

