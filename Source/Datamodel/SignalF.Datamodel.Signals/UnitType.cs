using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Signals
{
	public partial class UnitType : BusinessAttribute, SignalF.Datamodel.Signals.IUnitType
	{

		#region Private Members


		#endregion Private Members


		#region Constructors

		public UnitType()
		{
		}

		#endregion Constructors


		#region Properties

		EUnitType IUnitType.Value
		{
			get
			{
				try
				{
					string val = (Scotec.XMLDatabase.DAL.DataTypes.String)DataAttribute.Value;

					if(val.Length == 0)
						return new EUnitType();

					return (EUnitType)System.Enum.Parse(typeof(EUnitType), val);
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
					DataAttribute.Value = (Scotec.XMLDatabase.DAL.DataTypes.String)value.ToString();
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

		EUnitType IUnitType.DefaultValue
		{
			get
			{
				try
				{
					string val = (Scotec.XMLDatabase.DAL.DataTypes.String)DataAttribute.DefaultValue;

					if(val.Length == 0)
						return new EUnitType();

					return (EUnitType)System.Enum.Parse(typeof(EUnitType), val);
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

		// Override abstract Value property of BusinessObject implementation.
		public override object Value
		{
			get
			{
				try
				{
					return  ((IUnitType)this).Value;
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
					((IUnitType)this).Value = (EUnitType)value;
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

		// Override abstract DefaultValue property of BusinessObject implementation.
		public override object DefaultValue
		{
			get
			{
				try
				{
					return  ((IUnitType)this).DefaultValue;
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

		bool IUnitType.Validate(EUnitType value)
		{
			try
			{
				return DataAttribute.Validate(value.ToString());
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

		// Override abstract Validate method of BusinessObject implementation.
		public override bool Validate(object value)
		{
			try
			{
				return ((IUnitType)this).Validate((EUnitType)value);
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

		#endregion Interface Implementations

	}
}

