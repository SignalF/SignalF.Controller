using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial class SignalProcessorConfiguration : SignalF.Datamodel.Base.CoreObject, SignalF.Datamodel.Signals.ISignalProcessorConfiguration
	{
		#region Properties

		
		private const string DEFINITION_PROPERTY_NAME = "Definition";		
		SignalF.Datamodel.Signals.ISignalProcessorDefinition ISignalProcessorConfiguration.Definition
		{
			get
			{
				try
				{
					return BusinessSession.Factory.GetBusinessObject(DataObject.GetReference(DEFINITION_PROPERTY_NAME)) as SignalF.Datamodel.Signals.ISignalProcessorDefinition;
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
					var reference = DataObject.GetReference(DEFINITION_PROPERTY_NAME);
					var dataObject = (value!=null) ? ((BusinessObject)value).DataObject : null;

					if(reference == dataObject)
						return;
										
					DataObject.SetReference(DEFINITION_PROPERTY_NAME, (value!=null) ? ((BusinessObject)value).DataObject : null);
					AddModifiedProperty(DEFINITION_PROPERTY_NAME);
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

		
		SignalF.Datamodel.Signals.ISignalSinkConfigurationList ISignalProcessorConfiguration.SignalSinks
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Signals.ISignalSinkConfigurationList)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("SignalSinks"));
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
		
		SignalF.Datamodel.Signals.ISignalSourceConfigurationList ISignalProcessorConfiguration.SignalSources
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Signals.ISignalSourceConfigurationList)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("SignalSources"));
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
			var specificVisitor = visitor as ISignalProcessorConfigurationVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

