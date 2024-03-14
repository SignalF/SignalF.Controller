using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Configuration
{
	public partial class TaskConfiguration : BusinessObject, SignalF.Datamodel.Configuration.ITaskConfiguration
	{
		#region Properties

		
		private const string ID_PROPERTY_NAME = "id";		
		System.Guid ITaskConfiguration.Id
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
		System.String ITaskConfiguration.Name
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
		
		private const string PRIORITY_PROPERTY_NAME = "Priority";		
		System.Byte ITaskConfiguration.Priority
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Base.IUByte)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(PRIORITY_PROPERTY_NAME))).Value;
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
					var attribute = (SignalF.Datamodel.Base.IUByte)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(PRIORITY_PROPERTY_NAME));
					
					if(attribute.Value == (System.Byte)value)
						return;
					
					attribute.Value = (System.Byte)value;
					AddModifiedProperty(PRIORITY_PROPERTY_NAME);
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
		
		SignalF.Datamodel.Units.ITimeValue ITaskConfiguration.Raster
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Units.ITimeValue)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("Raster"));
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
		
		SignalF.Datamodel.Signals.ISignalProcessorConfigurationRefList ITaskConfiguration.SignalProcessorConfigurations
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Signals.ISignalProcessorConfigurationRefList)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("SignalProcessorConfigurations"));
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
		SignalF.Datamodel.Configuration.ETaskType ITaskConfiguration.Type
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Configuration.ITaskType)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(TYPE_PROPERTY_NAME))).Value;
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
					var attribute = (SignalF.Datamodel.Configuration.ITaskType)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(TYPE_PROPERTY_NAME));
					
					if(attribute.Value == (SignalF.Datamodel.Configuration.ETaskType)value)
						return;
					
					attribute.Value = (SignalF.Datamodel.Configuration.ETaskType)value;
					AddModifiedProperty(TYPE_PROPERTY_NAME);
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
			var specificVisitor = visitor as ITaskConfigurationVisitor<TResult>;
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

