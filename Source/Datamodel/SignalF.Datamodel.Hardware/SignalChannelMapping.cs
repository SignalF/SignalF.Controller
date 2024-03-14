using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial class SignalChannelMapping : BusinessObject, SignalF.Datamodel.Hardware.ISignalChannelMapping
	{
		#region Properties

		
		private const string CHANNELNUMBER_PROPERTY_NAME = "ChannelNumber";		
		System.Int32 ISignalChannelMapping.ChannelNumber
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Base.IInt)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(CHANNELNUMBER_PROPERTY_NAME))).Value;
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
					var attribute = (SignalF.Datamodel.Base.IInt)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(CHANNELNUMBER_PROPERTY_NAME));
					
					if(attribute.Value == (System.Int32)value)
						return;
					
					attribute.Value = (System.Int32)value;
					AddModifiedProperty(CHANNELNUMBER_PROPERTY_NAME);
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
		
		private const string SIGNALENDPOINTDEFINITION_PROPERTY_NAME = "SignalEndpointDefinition";		
		SignalF.Datamodel.Signals.ISignalEndpointDefinition ISignalChannelMapping.SignalEndpointDefinition
		{
			get
			{
				try
				{
					return BusinessSession.Factory.GetBusinessObject(DataObject.GetReference(SIGNALENDPOINTDEFINITION_PROPERTY_NAME)) as SignalF.Datamodel.Signals.ISignalEndpointDefinition;
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
					var reference = DataObject.GetReference(SIGNALENDPOINTDEFINITION_PROPERTY_NAME);
					var dataObject = (value!=null) ? ((BusinessObject)value).DataObject : null;

					if(reference == dataObject)
						return;
										
					DataObject.SetReference(SIGNALENDPOINTDEFINITION_PROPERTY_NAME, (value!=null) ? ((BusinessObject)value).DataObject : null);
					AddModifiedProperty(SIGNALENDPOINTDEFINITION_PROPERTY_NAME);
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
			var specificVisitor = visitor as ISignalChannelMappingVisitor<TResult>;
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

