﻿using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial class DynamicViscosityUnit : SignalF.Datamodel.Units.Unit, SignalF.Datamodel.Units.IDynamicViscosityUnit
	{
		#region Properties

		
		private const string UNIT_PROPERTY_NAME = "Unit";		
		Scotec.Math.Units.DynamicViscosity.Units IDynamicViscosityUnit.Unit
		{
			get
			{
				try
				{
					return ((SignalF.Datamodel.Units.IDynamicViscosity)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(UNIT_PROPERTY_NAME))).Value;
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
					var attribute = (SignalF.Datamodel.Units.IDynamicViscosity)BusinessSession.Factory.GetBusinessAttribute(DataObject.GetAttribute(UNIT_PROPERTY_NAME));
					
					if(attribute.Value == (Scotec.Math.Units.DynamicViscosity.Units)value)
						return;
					
					attribute.Value = (Scotec.Math.Units.DynamicViscosity.Units)value;
					AddModifiedProperty(UNIT_PROPERTY_NAME);
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
			var specificVisitor = visitor as IDynamicViscosityUnitVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

