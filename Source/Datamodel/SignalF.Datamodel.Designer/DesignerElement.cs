using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Designer
{
	public abstract partial class DesignerElement : BusinessObject, SignalF.Datamodel.Designer.IDesignerElement
	{
		#region Properties

		
		private const string ID_PROPERTY_NAME = "id";		
		System.Guid IDesignerElement.Id
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
		
		SignalF.Datamodel.Designer.IPosition IDesignerElement.Position
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Designer.IPosition)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("Position"));
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
		
		private const string SIGNALPROCESSOR_PROPERTY_NAME = "SignalProcessor";		
		SignalF.Datamodel.Signals.ISignalProcessorConfiguration IDesignerElement.SignalProcessor
		{
			get
			{
				try
				{
					return BusinessSession.Factory.GetBusinessObject(DataObject.GetReference(SIGNALPROCESSOR_PROPERTY_NAME)) as SignalF.Datamodel.Signals.ISignalProcessorConfiguration;
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
					var reference = DataObject.GetReference(SIGNALPROCESSOR_PROPERTY_NAME);
					var dataObject = (value!=null) ? ((BusinessObject)value).DataObject : null;

					if(reference == dataObject)
						return;
										
					DataObject.SetReference(SIGNALPROCESSOR_PROPERTY_NAME, (value!=null) ? ((BusinessObject)value).DataObject : null);
					AddModifiedProperty(SIGNALPROCESSOR_PROPERTY_NAME);
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

		
		SignalF.Datamodel.Designer.ISize IDesignerElement.Size
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Designer.ISize)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("Size"));
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



		bool  IDesignerElement.HasSize()
		{
			try
			{
				return DataObject.HasDataObject("Size");
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

		TSize IDesignerElement.CreateSize<TSize>()
		{
			try
			{
				Type type = typeof(TSize);
				string typeName = string.Format("{0}.{1}Type", type.Namespace, type.Name.Substring(1));

				AddModifiedProperty( "Size" );
				return (TSize)BusinessSession.Factory.GetBusinessObject(DataObject.CreateDataObject("Size", typeName));
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

		void  IDesignerElement.DeleteSize()
		{
			try
			{
				AddModifiedProperty( "Size" );
				DataObject.DeleteDataObject("Size");
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



		public virtual TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as IDesignerElementVisitor<TResult>;
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

