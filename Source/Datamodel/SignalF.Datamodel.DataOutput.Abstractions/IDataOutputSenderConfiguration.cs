using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.DataOutput
{
	public partial interface IDataOutputSenderConfiguration : SignalF.Datamodel.Base.ICoreObject
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IDataOutputSenderConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IDataOutputSenderConfiguration visitable);
	}
}

