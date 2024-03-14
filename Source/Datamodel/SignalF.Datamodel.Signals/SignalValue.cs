using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial class SignalValue : BusinessObject, SignalF.Datamodel.Signals.ISignalValue
	{
		#region Properties

		
		private const string SIGNALSOURCE_PROPERTY_NAME = "SignalSource";		
		SignalF.Datamodel.Signals.ISignalSourceConfiguration ISignalValue.SignalSource
		{
			get
			{
				try
				{
					return BusinessSession.Factory.GetBusinessObject(DataObject.GetReference(SIGNALSOURCE_PROPERTY_NAME)) as SignalF.Datamodel.Signals.ISignalSourceConfiguration;
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
					var reference = DataObject.GetReference(SIGNALSOURCE_PROPERTY_NAME);
					var dataObject = (value!=null) ? ((BusinessObject)value).DataObject : null;

					if(reference == dataObject)
						return;
										
					DataObject.SetReference(SIGNALSOURCE_PROPERTY_NAME, (value!=null) ? ((BusinessObject)value).DataObject : null);
					AddModifiedProperty(SIGNALSOURCE_PROPERTY_NAME);
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

		
		private const string UNITTYPE_PROPERTY_NAME = "UnitType";		
		SignalF.Datamodel.Signals.EUnitType ISignalValue.UnitType
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Signals.IUnitType)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(UNITTYPE_PROPERTY_NAME))).Value;
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
					var attribute = (SignalF.Datamodel.Signals.IUnitType)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(UNITTYPE_PROPERTY_NAME));
					
					if(attribute.Value == (SignalF.Datamodel.Signals.EUnitType)value)
						return;
					
					attribute.Value = (SignalF.Datamodel.Signals.EUnitType)value;
					AddModifiedProperty(UNITTYPE_PROPERTY_NAME);
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
		
		SignalF.Datamodel.Units.IValue ISignalValue.Value
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Units.IValue)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("Value"));
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


		bool  ISignalValue.HasValue()
		{
			try
			{
				return DataObject.HasDataObject("Value");
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

		TValue ISignalValue.CreateValue<TValue>()
		{
			try
			{
				Type type = typeof(TValue);
				string typeName = string.Format("{0}.{1}Type", type.Namespace, type.Name.Substring(1));

				AddModifiedProperty( "Value" );
				return (TValue)BusinessSession.Factory.GetBusinessObject(DataObject.CreateDataObject("Value", typeName));
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

		void  ISignalValue.DeleteValue()
		{
			try
			{
				AddModifiedProperty( "Value" );
				DataObject.DeleteDataObject("Value");
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
			var specificVisitor = visitor as ISignalValueVisitor<TResult>;
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

