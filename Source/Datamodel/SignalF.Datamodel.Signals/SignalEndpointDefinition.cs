using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial class SignalEndpointDefinition : BusinessObject, SignalF.Datamodel.Signals.ISignalEndpointDefinition
	{
		#region Properties

		
		private const string ID_PROPERTY_NAME = "id";		
		System.Guid ISignalEndpointDefinition.Id
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
		System.String ISignalEndpointDefinition.Name
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
		
		private const string UNITTYPE_PROPERTY_NAME = "UnitType";		
		SignalF.Datamodel.Signals.EUnitType ISignalEndpointDefinition.UnitType
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Signals.IUnitType)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(UNITTYPE_PROPERTY_NAME))).Value;
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
					var attribute = (SignalF.Datamodel.Signals.IUnitType)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(UNITTYPE_PROPERTY_NAME));
					
					if(attribute.Value == (SignalF.Datamodel.Signals.EUnitType)value)
						return;
					
					attribute.Value = (SignalF.Datamodel.Signals.EUnitType)value;
					AddModifiedProperty(UNITTYPE_PROPERTY_NAME);
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
			var specificVisitor = visitor as ISignalEndpointDefinitionVisitor<TResult>;
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

