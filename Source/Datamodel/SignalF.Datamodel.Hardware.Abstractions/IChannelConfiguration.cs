using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial interface IChannelConfiguration : SignalF.Datamodel.Base.ICoreObject
	{

		#region Properties

		#endregion Properties


		#region Methods

		#endregion Methods

	}

	public interface IChannelConfigurationVisitor<T> : Scotec.XMLDatabase.IVisitor<T>
	{
		T Visit(IChannelConfiguration visitable);
	}
}

