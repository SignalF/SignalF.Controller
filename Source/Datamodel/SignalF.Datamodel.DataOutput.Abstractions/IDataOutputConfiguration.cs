using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.DataOutput
{
	public partial interface IDataOutputConfiguration : IBusinessObject, Scotec.XMLDatabase.IVisitable
	{

		#region Properties

		SignalF.Datamodel.DataOutput.IDataOutputSenderConfigurationRefList DataOutputSenders { get; }

		System.Guid Id { get; }

		System.String Name { get; set; }

		SignalF.Datamodel.Signals.ISignalSourceConfigurationRefList SignalSources { get; }

		#endregion Properties


		#region Methods



		#endregion Methods

	}

	public interface IDataOutputConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IDataOutputConfiguration visitable);
	}
}

