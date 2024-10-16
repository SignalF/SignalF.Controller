using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Designer
{
	public partial class SignalProcessorElement : SignalF.Datamodel.Designer.DesignerElement, SignalF.Datamodel.Designer.ISignalProcessorElement
	{
		#region Properties

		
		SignalF.Datamodel.Designer.IPosition ISignalProcessorElement.Position
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
		SignalF.Datamodel.Signals.ISignalProcessorConfiguration ISignalProcessorElement.SignalProcessor
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

		
		SignalF.Datamodel.Designer.ISize ISignalProcessorElement.Size
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




		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as ISignalProcessorElementVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

