using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial class MassFlux : BusinessAttribute, SignalF.Datamodel.Units.IMassFlux
	{

		#region Private Members


		#endregion Private Members


		#region Constructors

		public MassFlux()
		{
		}

		#endregion Constructors


		#region Properties

		Scotec.Math.Units.MassFlux.Units IMassFlux.Value
		{
			get
			{
				try
				{
					string val = (Scotec.XMLDatabase.DAL.DataTypes.String)DataAttribute.Value;

					if(val.Length == 0)
						return new Scotec.Math.Units.MassFlux.Units();

					return (Scotec.Math.Units.MassFlux.Units)System.Enum.Parse(typeof(Scotec.Math.Units.MassFlux.Units), val);
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

		Scotec.Math.Units.MassFlux.Units IMassFlux.DefaultValue
		{
			get
			{
				try
				{
					string val = (Scotec.XMLDatabase.DAL.DataTypes.String)DataAttribute.DefaultValue;

					if(val.Length == 0)
						return new Scotec.Math.Units.MassFlux.Units();

					return (Scotec.Math.Units.MassFlux.Units)System.Enum.Parse(typeof(Scotec.Math.Units.MassFlux.Units), val);
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
					return  ((IMassFlux)this).Value;
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
					((IMassFlux)this).Value = (Scotec.Math.Units.MassFlux.Units)value;
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
					return  ((IMassFlux)this).DefaultValue;
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

		bool IMassFlux.Validate(Scotec.Math.Units.MassFlux.Units value)
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
				return ((IMassFlux)this).Validate((Scotec.Math.Units.MassFlux.Units)value);
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

