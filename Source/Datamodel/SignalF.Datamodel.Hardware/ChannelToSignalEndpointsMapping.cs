using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial class ChannelToSignalEndpointsMapping : BusinessObject, SignalF.Datamodel.Hardware.IChannelToSignalEndpointsMapping
	{
		#region Properties

		
		private const string CHANNEL_PROPERTY_NAME = "Channel";		
		SignalF.Datamodel.Hardware.IChannelConfiguration IChannelToSignalEndpointsMapping.Channel
		{
			get
			{
				try
				{
					return BusinessSession.Factory.GetBusinessObject(DataObject.GetReference(CHANNEL_PROPERTY_NAME)) as SignalF.Datamodel.Hardware.IChannelConfiguration;
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
					var reference = DataObject.GetReference(CHANNEL_PROPERTY_NAME);
					var dataObject = (value!=null) ? ((BusinessObject)value).DataObject : null;

					if(reference == dataObject)
						return;
										
					DataObject.SetReference(CHANNEL_PROPERTY_NAME, (value!=null) ? ((BusinessObject)value).DataObject : null);
					AddModifiedProperty(CHANNEL_PROPERTY_NAME);
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

		
		SignalF.Datamodel.Signals.ISignalEndpointConfigurationRefList IChannelToSignalEndpointsMapping.SignalEndpoints
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Signals.ISignalEndpointConfigurationRefList)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("SignalEndpoints"));
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
			var specificVisitor = visitor as IChannelToSignalEndpointsMappingVisitor<TResult>;
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

