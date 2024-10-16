using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Designer
{
	public partial interface ISignalProcessorElement : SignalF.Datamodel.Designer.IDesignerElement
	{

		#region Properties

		SignalF.Datamodel.Designer.IPosition Position { get; }

		SignalF.Datamodel.Signals.ISignalProcessorConfiguration SignalProcessor { get; set; }

		SignalF.Datamodel.Designer.ISize Size { get; }

		#endregion Properties


		#region Methods




		#endregion Methods

	}

	public interface ISignalProcessorElementVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ISignalProcessorElement visitable);
	}
}

