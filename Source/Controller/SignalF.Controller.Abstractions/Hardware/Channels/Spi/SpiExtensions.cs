#region

using System.Device.Gpio;
using System.Device.Spi;
using SignalF.Datamodel.Hardware;

#endregion

namespace SignalF.Controller.Hardware.Channels.Spi;

public static class SpiExtensions
{
    public static SpiMode Convert(this ESpiMode spiMode)
    {
        return spiMode switch
        {
            ESpiMode.Mode0 => SpiMode.Mode0, ESpiMode.Mode1 => SpiMode.Mode1, ESpiMode.Mode2 => SpiMode.Mode2, ESpiMode.Mode3 => SpiMode.Mode3,
            _ => throw new Exception("Unknown SPI Mode encountered.")
        };
    }

    public static ESpiMode Convert(this SpiMode spiMode)
    {
        return spiMode switch
        {
            SpiMode.Mode0 => ESpiMode.Mode0, SpiMode.Mode1 => ESpiMode.Mode1, SpiMode.Mode2 => ESpiMode.Mode2, SpiMode.Mode3 => ESpiMode.Mode3,
            _ => throw new Exception("Unknown SPI mode encountered.")
        };
    }

    public static PinValue Convert(this EGpioPinValue pinValue)
    {
        return pinValue switch
        {
            EGpioPinValue.Low => PinValue.Low, EGpioPinValue.High => PinValue.High, _ => throw new Exception("Unknown pin value encountered.")
        };
    }

    public static EGpioPinValue Convert(this PinValue pinValue)
    {
        return (bool)pinValue switch
        {
            false => EGpioPinValue.Low,
            true => EGpioPinValue.High
        };
    }

    public static DataFlow Convert(this ESpiDataFlow dataFlow)
    {
        return dataFlow switch
        {
            ESpiDataFlow.LsbFirst => DataFlow.LsbFirst, ESpiDataFlow.MsbFirst => DataFlow.MsbFirst, _ => throw new Exception("Unknown data flow encountered.")
        };
    }

    public static ESpiDataFlow Convert(this DataFlow dataFlow)
    {
        return dataFlow switch
        {
            DataFlow.LsbFirst => ESpiDataFlow.LsbFirst, DataFlow.MsbFirst => ESpiDataFlow.MsbFirst, _ => throw new Exception("Unknown data flow encountered.")
        };
    }
}
