using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial class SignalProcessorTemplate : SignalF.Datamodel.Base.CoreObject, SignalF.Datamodel.Signals.ISignalProcessorTemplate
	{
		#region Properties

		
		SignalF.Datamodel.Signals.ISignalEndpointDefinitionList ISignalProcessorTemplate.SignalSinkDefinitions
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
		
		SignalF.Datamodel.Signals.ISignalEndpointDefinitionList ISignalProcessorTemplate.SignalSourceDefinitions
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
		#endregion Properties


		#region Interface Implementations



		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as ISignalProcessorTemplateVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

