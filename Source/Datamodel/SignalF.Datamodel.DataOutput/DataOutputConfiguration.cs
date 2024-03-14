using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.DataOutput
{
	public partial class DataOutputConfiguration : BusinessObject, SignalF.Datamodel.DataOutput.IDataOutputConfiguration
	{
		#region Properties

		
		SignalF.Datamodel.DataOutput.IDataOutputSenderConfigurationRefList IDataOutputConfiguration.DataOutputSenders
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.DataOutput.IDataOutputSenderConfigurationRefList)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("DataOutputSenders"));
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
		System.Guid IDataOutputConfiguration.Id
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
		System.String IDataOutputConfiguration.Name
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
		
		SignalF.Datamodel.Signals.ISignalSourceConfigurationRefList IDataOutputConfiguration.SignalSources
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Signals.ISignalSourceConfigurationRefList)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("SignalSources"));
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
			var specificVisitor = visitor as IDataOutputConfigurationVisitor<TResult>;
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

