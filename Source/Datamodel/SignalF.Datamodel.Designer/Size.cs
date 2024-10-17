using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Designer
{
	public partial class Size : BusinessObject, SignalF.Datamodel.Designer.ISize
	{
		#region Properties

		
		private const string HEIGHT_PROPERTY_NAME = "Height";		
		System.Double ISize.Height
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Base.IDouble)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(HEIGHT_PROPERTY_NAME))).Value;
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
					var attribute = (SignalF.Datamodel.Base.IDouble)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(HEIGHT_PROPERTY_NAME));
					
					if(attribute.Value == (System.Double)value)
						return;
					
					attribute.Value = (System.Double)value;
					AddModifiedProperty(HEIGHT_PROPERTY_NAME);
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
		
		private const string WIDTH_PROPERTY_NAME = "Width";		
		System.Double ISize.Width
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Base.IDouble)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(WIDTH_PROPERTY_NAME))).Value;
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
					var attribute = (SignalF.Datamodel.Base.IDouble)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(WIDTH_PROPERTY_NAME));
					
					if(attribute.Value == (System.Double)value)
						return;
					
					attribute.Value = (System.Double)value;
					AddModifiedProperty(WIDTH_PROPERTY_NAME);
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
			var specificVisitor = visitor as ISizeVisitor<TResult>;
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

