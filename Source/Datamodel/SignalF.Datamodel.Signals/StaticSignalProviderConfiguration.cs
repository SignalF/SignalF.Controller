using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial class StaticSignalProviderConfiguration : SignalF.Datamodel.Signals.SignalProcessorConfiguration, SignalF.Datamodel.Signals.IStaticSignalProviderConfiguration
	{
		#region Properties

		
		SignalF.Datamodel.Signals.ISignalValueList IStaticSignalProviderConfiguration.SignalValues
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Signals.ISignalValueList)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("SignalValues"));
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
			var specificVisitor = visitor as IStaticSignalProviderConfigurationVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

