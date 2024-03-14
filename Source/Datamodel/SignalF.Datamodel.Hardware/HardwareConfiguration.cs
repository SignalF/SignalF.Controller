using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial class HardwareConfiguration : BusinessObject, SignalF.Datamodel.Hardware.IHardwareConfiguration
	{
		#region Properties

		
		SignalF.Datamodel.Hardware.IChannelGroupConfigurationList IHardwareConfiguration.ChannelGroups
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Hardware.IChannelGroupConfigurationList)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("ChannelGroups"));
				}
				catch(Scotec.XMLDatabase.DataException e)
				{
					throw new BusinessException((EBusinessError)e.DataError, e.Message, e);
				}
				catch(Exception e)
				{
					throw new BusinessException(EBusinessError.Document, "Caught unhandled exception.", e);
				}
			}
		}
		#endregion Properties


		#region Interface Implementations



		public virtual TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as IHardwareConfigurationVisitor<TResult>;
			if (specificVisitor != null)
				return specificVisitor.Visit(this);

			var objectVisitor = visitor as IObjectVisitor<TResult>;
			
			if (objectVisitor != null)
				return objectVisitor.Visit(this);
			throw new NotSupportedException("Visitor of type " + visitor.GetType().FullName + " does not support visiting objects of type " + GetType().FullName + '.');
		}

		#endregion Interface Implementations

	}
}

