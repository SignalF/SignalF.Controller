using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Base
{
	public abstract partial class CoreObject : BusinessObject, SignalF.Datamodel.Base.ICoreObject
	{
		#region Properties

		
		SignalF.Datamodel.Base.IConfiguration ICoreObject.Configuration
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Base.IConfiguration)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("Configuration"));
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
		
		private const string ID_PROPERTY_NAME = "id";		
		System.Guid ICoreObject.Id
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Base.IIdentifier)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(ID_PROPERTY_NAME))).Value;
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
		
		private const string NAME_PROPERTY_NAME = "Name";		
		System.String ICoreObject.Name
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Base.IString)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(NAME_PROPERTY_NAME))).Value;
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
						throw new ArgumentException("Value must not be null.");
					var attribute = (SignalF.Datamodel.Base.IString)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(NAME_PROPERTY_NAME));
					
					if(attribute.Value == (System.String)value)
						return;
					
					attribute.Value = (System.String)value;
					AddModifiedProperty(NAME_PROPERTY_NAME);
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
		
		private const string TYPE_PROPERTY_NAME = "Type";		
		System.String ICoreObject.Type
		{
			get
			{
				try
				{
					if(DataObject.HasAttribute(TYPE_PROPERTY_NAME))
						return ((SignalF.Datamodel.Base.IString)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(TYPE_PROPERTY_NAME))).Value;
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
						if(DataObject.HasAttribute(TYPE_PROPERTY_NAME))
						{
							DataObject.DeleteAttribute(TYPE_PROPERTY_NAME);
							AddModifiedProperty( TYPE_PROPERTY_NAME );
						}
					}
					else
					{
						if(DataObject.HasAttribute(TYPE_PROPERTY_NAME))
						{
							var attribute = (SignalF.Datamodel.Base.IString)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(TYPE_PROPERTY_NAME));
							if(attribute.Value == (System.String)value)
								return;

							attribute.Value = (System.String)value;
							AddModifiedProperty(TYPE_PROPERTY_NAME);
						}
						else
						{
							((SignalF.Datamodel.Base.IString)BusinessSession.Factory.GetBusinessAttribute(DataObject.CreateAttribute(TYPE_PROPERTY_NAME))).Value = (System.String)value;
							AddModifiedProperty(TYPE_PROPERTY_NAME);
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
			var specificVisitor = visitor as ICoreObjectVisitor<TResult>;
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

