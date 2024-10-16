﻿using System;
using Scotec.XMLDatabase;


namespace SignalF.Datamodel.Devices
{
	public partial class TcpDeviceTemplate : SignalF.Datamodel.Hardware.DeviceTemplate, SignalF.Datamodel.Devices.ITcpDeviceTemplate
	{
		#region Properties

		#endregion Properties


		#region Interface Implementations

		public override TResult Apply<TResult>(IVisitor<TResult> visitor)
		{
			var specificVisitor = visitor as ITcpDeviceTemplateVisitor<TResult>;
			return (specificVisitor != null) ? specificVisitor.Visit(this) : base.Apply(visitor);
		}

		#endregion Interface Implementations

	}
}

