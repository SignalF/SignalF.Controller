namespace SignalF.Controller.DataOutput;

public interface IDataOutputFactory
{
    /// <summary>
    ///     Creates new instance of DataOutput
    /// </summary>
    /// <returns>The new DataOutput</returns>
    IDataOutput CreateDataOutput();
}
