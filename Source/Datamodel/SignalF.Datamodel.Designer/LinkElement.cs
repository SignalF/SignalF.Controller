using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Designer
{
	public partial class LinkElement : SignalF.Datamodel.Designer.DesignerElement, SignalF.Datamodel.Designer.ILinkElement
	{
		#region Properties

		
		private const string CONNECTION_PROPERTY_NAME = "Connection";		
		SignalF.Datamodel.Signals.ISignalConnection ILinkElement.Connection
		{
			get
			{
				try
				{
					return BusinessSession.Factory.GetBusinessObject(DataObject.GetReference(CONNECTION_PROPERTY_NAME)) as SignalF.Datamodel.Signals.ISignalConnection;
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
					var reference = DataObject.GetReference(CONNECTION_PROPERTY_NAME);
					var dataObject = (value!=null) ? ((BusinessObject)value).DataObject : null;

					if(reference == dataObject)
						return;
										
					DataObject.SetReference(CONNECTION_PROPERTY_NAME, (value!=null) ? ((BusinessObject)value).DataObject : null);
					AddModifiedProperty(CONNECTION_PROPERTY_NAME);
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

		
		SignalF.Datamodel.Designer.IPointList ILinkElement.Vertices
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Designer.IPointList)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("Vertices"));
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



		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as ILinkElementVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

