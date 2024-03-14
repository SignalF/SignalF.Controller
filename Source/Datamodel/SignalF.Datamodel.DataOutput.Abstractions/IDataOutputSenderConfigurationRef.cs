using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.DataOutput
{
	public partial interface IDataOutputSenderConfigurationRef : SignalF.Datamodel.Base.IReference
	{

	}

	public interface IDataOutputSenderConfigurationRefVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IDataOutputSenderConfigurationRef visitable);
	}
}

