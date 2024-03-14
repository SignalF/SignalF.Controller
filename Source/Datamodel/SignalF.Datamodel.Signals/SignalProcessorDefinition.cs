using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial class SignalProcessorDefinition : SignalF.Datamodel.Base.CoreObject, SignalF.Datamodel.Signals.ISignalProcessorDefinition
	{
		#region Properties

		
		SignalF.Datamodel.Signals.ISignalEndpointDefinitionList ISignalProcessorDefinition.SignalSinkDefinitions
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Signals.ISignalEndpointDefinitionList)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("SignalSinkDefinitions"));
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
		
		SignalF.Datamodel.Signals.ISignalEndpointDefinitionList ISignalProcessorDefinition.SignalSourceDefinitions
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Signals.ISignalEndpointDefinitionList)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("SignalSourceDefinitions"));
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
		
		private const string TEMPLATE_PROPERTY_NAME = "Template";		
		SignalF.Datamodel.Signals.ISignalProcessorTemplate ISignalProcessorDefinition.Template
		{
			get
			{
				try
				{
					return BusinessSession.Factory.GetBusinessObject(DataObject.GetReference(TEMPLATE_PROPERTY_NAME)) as SignalF.Datamodel.Signals.ISignalProcessorTemplate;
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
					var reference = DataObject.GetReference(TEMPLATE_PROPERTY_NAME);
					var dataObject = (value!=null) ? ((BusinessObject)value).DataObject : null;

					if(reference == dataObject)
						return;
										
					DataObject.SetReference(TEMPLATE_PROPERTY_NAME, (value!=null) ? ((BusinessObject)value).DataObject : null);
					AddModifiedProperty(TEMPLATE_PROPERTY_NAME);
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
			var specificVisitor = visitor as ISignalProcessorDefinitionVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

