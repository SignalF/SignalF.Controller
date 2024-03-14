using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public abstract partial class SignalConfiguration : SignalF.Datamodel.Signals.SignalEndpointConfiguration, SignalF.Datamodel.Signals.ISignalConfiguration
	{
		#region Properties

		
		SignalF.Datamodel.Units.IUnit ISignalConfiguration.Unit
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Units.IUnit)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("Unit"));
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

		bool  ISignalConfiguration.HasUnit()
		{
			try
			{
				return DataObject.HasDataObject("Unit");
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

		TUnit ISignalConfiguration.CreateUnit<TUnit>()
		{
			try
			{
				Type type = typeof(TUnit);
				string typeName = string.Format("{0}.{1}Type", type.Namespace, type.Name.Substring(1));

				AddModifiedProperty( "Unit" );
				return (TUnit)BusinessSession.Factory.GetBusinessObject(DataObject.CreateDataObject("Unit", typeName));
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

		void  ISignalConfiguration.DeleteUnit()
		{
			try
			{
				AddModifiedProperty( "Unit" );
				DataObject.DeleteDataObject("Unit");
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


		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as ISignalConfigurationVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

