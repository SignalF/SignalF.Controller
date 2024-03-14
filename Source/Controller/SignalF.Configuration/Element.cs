using SignalF.Datamodel.Signals;
using SignalF.Datamodel.Workflow;
using Scotec.XMLDatabase;

namespace SignalF.Configuration;

public abstract class Element<TConfigElement> where TConfigElement : IBusinessObject
{
    public Element<TConfigElement> SetConfigurationData<TConfigurationData>(TConfigurationData data)
    {
        return this;
    }
    public Guid Id { get; } = Guid.NewGuid();
    public string? Name { get; private set; }

    public Element<TConfigElement> SetName(string name)
    {
        Name = name;
        return this;
    }

    protected virtual void Build(TConfigElement configElement)
    {

    }


    class A<T> where T : ISignalProcessorTemplate
    {
        protected virtual T X(T param)
        {
            return default(T);
        }

    }

    class B<T> : A<T> where T : IProcessControlTemplate
    {
        protected override T X(T param)
        {
            return default(T);
        }
    }
}
