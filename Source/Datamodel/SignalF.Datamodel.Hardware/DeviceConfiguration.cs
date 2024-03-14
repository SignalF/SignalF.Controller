﻿using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Hardware
{
	public partial class DeviceConfiguration : SignalF.Datamodel.Signals.SignalProcessorConfiguration, SignalF.Datamodel.Hardware.IDeviceConfiguration
	{
		#region Properties

		#endregion Properties


		#region Interface Implementations

		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as IDeviceConfigurationVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

