using SignalF.Configuration;
using SignalF.Configuration.Integration;
using SignalF.Configuration.Devices;
using SignalF.Controller.Hardware.Channels;
using SignalF.Controller.Signals.Devices;
using SignalF.Datamodel.Configuration;
using SignalF.Datamodel.Signals;
using SignalF.Configuration.DataOutput;

//namespace GeneratorTest
namespace SourceGenerator.dev
{
    [Device]
    //[Device(OptionsType = typeof(MyOptions))]
    public class Class2 : IDevice
    {
        public Guid Id { get; }
        public string Name { get; }
        public void Configure(ISignalProcessorConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        public void Execute(ETaskType taskType)
        {
            throw new NotImplementedException();
        }

        public void AssignChannels(IList<IChannel> channels)
        {
            throw new NotImplementedException();
        }
    }


}
