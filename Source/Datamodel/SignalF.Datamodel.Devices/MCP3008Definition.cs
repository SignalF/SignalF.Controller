using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial class MCP3008Definition : SignalF.Datamodel.Hardware.DeviceDefinition, SignalF.Datamodel.Devices.IMCP3008Definition
	{
		#region Properties

		
		SignalF.Datamodel.Hardware.ISignalChannelMappingList IMCP3008Definition.SignalChannelMappings
		{
			get
			{
				try
				{
					return (SignalF.Datamodel.Hardware.ISignalChannelMappingList)BusinessSession.Factory.GetBusinessObject(DataObject.GetDataObject("SignalChannelMappings"));
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


		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as IMCP3008DefinitionVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

