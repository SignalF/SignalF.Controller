using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Base
{
	public partial class Reference : BusinessObject, SignalF.Datamodel.Base.IReference
	{
		#region Properties

		
		private const string IDREF_PROPERTY_NAME = "idRef";		
		System.Guid? IReference.IdRef
		{
			get
			{
				try
				{
					if(DataObject.HasAttribute(IDREF_PROPERTY_NAME))
						return ((SignalF.Datamodel.Base.IIdentifierRef)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(IDREF_PROPERTY_NAME))).Value;
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
						if(DataObject.HasAttribute(IDREF_PROPERTY_NAME))
						{
							DataObject.DeleteAttribute(IDREF_PROPERTY_NAME);
							AddModifiedProperty( IDREF_PROPERTY_NAME );
						}
					}
					else
					{
						if(DataObject.HasAttribute(IDREF_PROPERTY_NAME))
						{
							var attribute = (SignalF.Datamodel.Base.IIdentifierRef)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(IDREF_PROPERTY_NAME));
							if(attribute.Value == (System.Guid)value)
								return;

							attribute.Value = (System.Guid)value;
							AddModifiedProperty(IDREF_PROPERTY_NAME);
						}
						else
						{
							((SignalF.Datamodel.Base.IIdentifierRef)BusinessSession.Factory.GetBusinessAttribute(DataObject.CreateAttribute(IDREF_PROPERTY_NAME))).Value = (System.Guid)value;
							AddModifiedProperty(IDREF_PROPERTY_NAME);
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
		
		private const string LOCATION_PROPERTY_NAME = "location";		
		System.String IReference.Location
		{
			get
			{
				try
				{
					if(DataObject.HasAttribute(LOCATION_PROPERTY_NAME))
						return ((SignalF.Datamodel.Base.IString)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(LOCATION_PROPERTY_NAME))).Value;
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
						if(DataObject.HasAttribute(LOCATION_PROPERTY_NAME))
						{
							DataObject.DeleteAttribute(LOCATION_PROPERTY_NAME);
							AddModifiedProperty( LOCATION_PROPERTY_NAME );
						}
					}
					else
					{
						if(DataObject.HasAttribute(LOCATION_PROPERTY_NAME))
						{
							var attribute = (SignalF.Datamodel.Base.IString)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(LOCATION_PROPERTY_NAME));
							if(attribute.Value == (System.String)value)
								return;

							attribute.Value = (System.String)value;
							AddModifiedProperty(LOCATION_PROPERTY_NAME);
						}
						else
						{
							((SignalF.Datamodel.Base.IString)BusinessSession.Factory.GetBusinessAttribute(DataObject.CreateAttribute(LOCATION_PROPERTY_NAME))).Value = (System.String)value;
							AddModifiedProperty(LOCATION_PROPERTY_NAME);
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
			var specificVisitor = visitor as IReferenceVisitor<TResult>;
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

