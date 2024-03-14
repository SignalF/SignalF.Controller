using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial class Acceleration : BusinessAttribute, SignalF.Datamodel.Units.IAcceleration
	{

		#region Private Members


		#endregion Private Members


		#region Constructors

		public Acceleration()
		{
		}

		#endregion Constructors


		#region Properties

		Scotec.Math.Units.Acceleration.Units IAcceleration.Value
		{
			get
			{
				try
				{
					string val = (Scotec.XMLDatabase.DAL.DataTypes.String)DataAttribute.Value;

					if(val.Length == 0)
						return new Scotec.Math.Units.Acceleration.Units();

					return (Scotec.Math.Units.Acceleration.Units)System.Enum.Parse(typeof(Scotec.Math.Units.Acceleration.Units), val);
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

		Scotec.Math.Units.Acceleration.Units IAcceleration.DefaultValue
		{
			get
			{
				try
				{
					string val = (Scotec.XMLDatabase.DAL.DataTypes.String)DataAttribute.DefaultValue;

					if(val.Length == 0)
						return new Scotec.Math.Units.Acceleration.Units();

					return (Scotec.Math.Units.Acceleration.Units)System.Enum.Parse(typeof(Scotec.Math.Units.Acceleration.Units), val);
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
					return  ((IAcceleration)this).Value;
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
					((IAcceleration)this).Value = (Scotec.Math.Units.Acceleration.Units)value;
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
					return  ((IAcceleration)this).DefaultValue;
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

		bool IAcceleration.Validate(Scotec.Math.Units.Acceleration.Units value)
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
				return ((IAcceleration)this).Validate((Scotec.Math.Units.Acceleration.Units)value);
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

