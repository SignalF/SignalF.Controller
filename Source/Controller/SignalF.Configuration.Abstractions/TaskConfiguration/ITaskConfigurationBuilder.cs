using Scotec.Math.Units;
using SignalF.Datamodel.Configuration;

namespace SignalF.Configuration.TaskConfiguration;

public interface ITaskConfigurationBuilder
{
    ITaskConfigurationBuilder AddTask(string taskName, byte priority, ETaskType taskType, double raster, Time.Units unit);

    void Build(IControllerConfiguration configuration);
}
