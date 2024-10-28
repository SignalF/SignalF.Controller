using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Designer
{
	public partial interface ILinkElement : SignalF.Datamodel.Designer.IDesignerElement
	{

		#region Properties

		SignalF.Datamodel.Signals.ISignalConnection Connection { get; set; }

		SignalF.Datamodel.Designer.IPointList Vertices { get; }

		#endregion Properties


		#region Methods



		#endregion Methods

	}

	public interface ILinkElementVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(ILinkElement visitable);
	}
}

