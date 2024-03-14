#region

using System;
using System.Linq;
using SignalF.Controller.Hardware.DeviceBindings;
using SignalF.Datamodel.Hardware;

#endregion

namespace SignalF.Controller.Hardware.Channels.I2c;

public sealed class I2cChannelGroup : ChannelGroup<II2cChannelGroupConfiguration>, II2cChannelGroup
{
    private readonly object _deviceLock = new();
    private int[] _deviceAddresses;

    public I2cChannelGroup(II2cDeviceBinding i2cDeviceBinding)
    {
        I2CDeviceBinding = i2cDeviceBinding;
    }

    private II2cDeviceBinding I2CDeviceBinding { get; }

    public override void Open()
    {
        I2CDeviceBinding.Open();
    }

    public override void Close()
    {
        I2CDeviceBinding.Close();
    }

    public void Read(int deviceAddress, Span<byte> buffer)
    {
        I2CDeviceBinding.Read(deviceAddress, buffer);
    }

    public byte ReadByte(int deviceAddress)
    {
        return I2CDeviceBinding.ReadByte(deviceAddress);
    }

    public void Write(int deviceAddress, Span<byte> buffer)
    {
        I2CDeviceBinding.Write(deviceAddress, buffer);
    }

    public void WriteByte(int deviceAddress, byte data)
    {
        I2CDeviceBinding.WriteByte(deviceAddress, data);
    }

    public void WriteRead(int deviceAddress, Span<byte> writeBuffer, Span<byte> readBuffer)
    {
        I2CDeviceBinding.WriteRead(deviceAddress, writeBuffer, readBuffer);
    }

    protected override void OnConfigure(II2cChannelGroupConfiguration configuration)
    {
        _deviceAddresses = configuration.Channels.Cast<II2cChannelConfiguration>()
                                        .Select(channel => channel.DeviceAddress)
                                        .ToArray();

        I2CDeviceBinding.ConfigureDevices(_deviceAddresses);
    }
}
