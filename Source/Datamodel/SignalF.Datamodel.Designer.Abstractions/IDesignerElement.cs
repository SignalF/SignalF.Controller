using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Designer
{
	public partial interface IDesignerElement : IBusinessObject, Scotec.XMLDatabase.IVisitable
	{

		#region Properties

		System.Guid Id { get; }

		SignalF.Datamodel.Designer.IPosition Position { get; }

		SignalF.Datamodel.Signals.ISignalProcessorConfiguration SignalProcessor { get; set; }

		SignalF.Datamodel.Designer.ISize Size { get; }

		#endregion Properties


		#region Methods



		bool HasSize();
		TSize CreateSize<TSize>() where TSize : SignalF.Datamodel.Designer.ISize;
		void DeleteSize();

		#endregion Methods

	}

	public interface IDesignerElementVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IDesignerElement visitable);
	}
}

