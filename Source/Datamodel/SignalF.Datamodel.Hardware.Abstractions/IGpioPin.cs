using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface IGpioPin : IBusinessObject, Scotec.XMLDatabase.IVisitable
	{

		#region Properties

		SignalF.Datamodel.Hardware.IGpioPinConfiguration Configuration { get; }

		System.String Designation { get; set; }

		System.Guid Id { get; }

		System.Int32 PinNumber { get; set; }

		#endregion Properties


		#region Methods


		#endregion Methods

	}

	public interface IGpioPinVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IGpioPin visitable);
	}
}

