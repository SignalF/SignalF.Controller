﻿using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IAngleValue : SignalF.Datamodel.Units.IValue
	{
		#region Properties

		Scotec.Math.Units.Angle.Units Unit { get; set; }
		Scotec.Math.Units.Angle Value { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IAngleValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IAngleValue visitable);
	}
}

