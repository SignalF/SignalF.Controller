using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Base
{
	public partial class DateTime : BusinessAttribute, SignalF.Datamodel.Base.IDateTime
	{

		#region Private Members


		#endregion Private Members


		#region Constructors

		public DateTime()
		{
		}

		#endregion Constructors


		#region Properties

		System.DateTime IDateTime.Value
		{
			get
			{
				try
				{
					return (System.DateTime) (Scotec.XMLDatabase.DAL.DataTypes.DateTime)DataAttribute.Value;
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
					DataAttribute.Value = (Scotec.XMLDatabase.DAL.DataTypes.DateTime)value;
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

		System.DateTime IDateTime.DefaultValue
		{
			get
			{
				try
				{
					return (System.DateTime) (Scotec.XMLDatabase.DAL.DataTypes.DateTime)DataAttribute.DefaultValue;
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
					return  ((IDateTime)this).Value;
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
					((IDateTime)this).Value = (System.DateTime)value;
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
					return  ((IDateTime)this).DefaultValue;
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

		bool IDateTime.Validate(System.DateTime value)
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
				return ((IDateTime)this).Validate((System.DateTime)value);
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

