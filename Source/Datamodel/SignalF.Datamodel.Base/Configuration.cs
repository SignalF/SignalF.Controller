using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Base
{
	public partial class Configuration : BusinessObject, SignalF.Datamodel.Base.IConfiguration
	{
		#region Properties

		
		private const string DATA_PROPERTY_NAME = "Data";		
		System.String IConfiguration.Data
		{
			get
			{
				try
				{
					if(DataObject.HasAttribute(DATA_PROPERTY_NAME))
						return ((SignalF.Datamodel.Base.IString)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(DATA_PROPERTY_NAME))).Value;
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
						if(DataObject.HasAttribute(DATA_PROPERTY_NAME))
						{
							DataObject.DeleteAttribute(DATA_PROPERTY_NAME);
							AddModifiedProperty( DATA_PROPERTY_NAME );
						}
					}
					else
					{
						if(DataObject.HasAttribute(DATA_PROPERTY_NAME))
						{
							var attribute = (SignalF.Datamodel.Base.IString)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(DATA_PROPERTY_NAME));
							if(attribute.Value == (System.String)value)
								return;

							attribute.Value = (System.String)value;
							AddModifiedProperty(DATA_PROPERTY_NAME);
						}
						else
						{
							((SignalF.Datamodel.Base.IString)BusinessSession.Factory.GetBusinessAttribute(DataObject.CreateAttribute(DATA_PROPERTY_NAME))).Value = (System.String)value;
							AddModifiedProperty(DATA_PROPERTY_NAME);
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
			var specificVisitor = visitor as IConfigurationVisitor<TResult>;
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

