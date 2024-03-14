using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Configuration
{
	public partial interface ITaskConfiguration : IBusinessObject, Scotec.XMLDatabase.IVisitable
	{

		#region Properties

		System.Guid Id { get; }

		System.String Name { get; set; }

		System.Byte Priority { get; set; }

		SignalF.Datamodel.Units.ITimeValue Raster { get; }

		SignalF.Datamodel.Signals.ISignalProcessorConfigurationRefList SignalProcessorConfigurations { get; }

		SignalF.Datamodel.Configuration.ETaskType Type { get; set; }

		#endregion Properties


		#region Methods



		#endregion Methods

	}

	public interface ITaskConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ITaskConfiguration visitable);
	}
}

