using SignalF.Configuration;
using SignalF.Configuration.Integration;
using SignalF.Configuration.Devices;
using SignalF.Controller.Hardware.Channels;
using SignalF.Controller.Signals.Devices;
using SignalF.Datamodel.Configuration;
using SignalF.Datamodel.Signals;
using SignalF.Configuration.DataOutput;
using SignalF.Controller.Signals.Calculators;

//namespace GeneratorTest
namespace SourceGenerator.dev
{
    [Calculator]
    //[Device(OptionsType = typeof(MyOptions))]
    public class Class2 : ICalculator
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
