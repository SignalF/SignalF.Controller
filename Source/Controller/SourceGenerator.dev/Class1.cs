using SignalF.Configuration;
using SignalF.Configuration.DataOutput;
using SignalF.Configuration.Integration;
using SignalF.Configuration.Devices;
using SignalF.Controller.DataOutput;
using SignalF.Controller.Hardware.Channels;
using SignalF.Controller.Signals;
using SignalF.Controller.Signals.Devices;
using SignalF.Datamodel.Configuration;
using SignalF.Datamodel.DataOutput;
using SignalF.Datamodel.Signals;

//namespace GeneratorTest
namespace SourceGenerator.dev
{
    [DataOutputSender]
    //[Device(OptionsType = typeof(MyOptions))]
    public class Class1 : IDataOutputSender
    {
        public void Configure(IDataOutputSenderConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        public void SendValues(Signal[] values)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public Guid Id { get; }
        public string Name { get; }
    }

}
