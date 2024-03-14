using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public abstract partial class Value : BusinessObject, SignalF.Datamodel.Units.IValue
	{
		#region Properties

		
		private const string SIVALUE_PROPERTY_NAME = "SIValue";		
		System.Double? IValue.SIValue
		{
			get
			{
				try
				{
					if(DataObject.HasAttribute(SIVALUE_PROPERTY_NAME))
						return ((SignalF.Datamodel.Base.IDouble)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(SIVALUE_PROPERTY_NAME))).Value;
					return null;
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
					if(value == null)
					{
						if(DataObject.HasAttribute(SIVALUE_PROPERTY_NAME))
						{
							DataObject.DeleteAttribute(SIVALUE_PROPERTY_NAME);
							AddModifiedProperty( SIVALUE_PROPERTY_NAME );
						}
					}
					else
					{
						if(DataObject.HasAttribute(SIVALUE_PROPERTY_NAME))
						{
							var attribute = (SignalF.Datamodel.Base.IDouble)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(SIVALUE_PROPERTY_NAME));
							if(attribute.Value == (System.Double)value)
								return;

							attribute.Value = (System.Double)value;
							AddModifiedProperty(SIVALUE_PROPERTY_NAME);
						}
						else
						{
							((SignalF.Datamodel.Base.IDouble)BusinessSession.Factory.GetBusinessAttribute(DataObject.CreateAttribute(SIVALUE_PROPERTY_NAME))).Value = (System.Double)value;
							AddModifiedProperty(SIVALUE_PROPERTY_NAME);
						}
					}
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
			var specificVisitor = visitor as IValueVisitor<TResult>;
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

