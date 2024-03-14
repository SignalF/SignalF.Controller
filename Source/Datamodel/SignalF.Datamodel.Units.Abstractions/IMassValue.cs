using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Units
{
	public partial interface IMassValue : SignalF.Datamodel.Units.IValue
	{
		#region Properties

		Scotec.Math.Units.Mass.Units Unit { get; set; }
		Scotec.Math.Units.Mass Value { get; set; }

		
		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IMassValueVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IMassValue visitable);
	}
}

