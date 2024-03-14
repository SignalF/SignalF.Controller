using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Base
{
	public partial class Integer : BusinessAttribute, SignalF.Datamodel.Base.IInteger
	{

		#region Private Members


		#endregion Private Members


		#region Constructors

		public Integer()
		{
		}

		#endregion Constructors


		#region Properties

		System.Decimal IInteger.Value
		{
			get
			{
				try
				{
					return (System.Decimal) (Scotec.XMLDatabase.DAL.DataTypes.Integer)DataAttribute.Value;
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
					DataAttribute.Value = (Scotec.XMLDatabase.DAL.DataTypes.Integer)value;
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

		System.Decimal IInteger.DefaultValue
		{
			get
			{
				try
				{
					return (System.Decimal) (Scotec.XMLDatabase.DAL.DataTypes.Integer)DataAttribute.DefaultValue;
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
					return  ((IInteger)this).Value;
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
					((IInteger)this).Value = (System.Decimal)value;
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
					return  ((IInteger)this).DefaultValue;
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

		bool IInteger.Validate(System.Decimal value)
		{
			try
			{
				return DataAttribute.Validate(value);
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
				return ((IInteger)this).Validate((System.Decimal)value);
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

