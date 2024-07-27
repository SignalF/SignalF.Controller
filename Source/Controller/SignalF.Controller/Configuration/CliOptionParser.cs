#region

using Mono.Options;

namespace SignalF.Controller.Configuration;

#endregion

public static class CliOptionParser
{
    private static readonly OptionSet OptionSet;
    private static string s_configuration;
    private static string s_procedureName;
    private static string s_procedureId;
    private static string s_assemblyName;
    private static string s_assemblyDirectory;
    private static bool s_online;
    private static bool s_help;

    static CliOptionParser()
    {
        OptionSet = new OptionSet
        {
            { "a|assembly=", "The name of the control procedure to run.", a => s_assemblyName = a },
            { "c|configuration=", "The name of the configuration.", c => s_configuration = c },
            { "d|directory=", "The directory of the assembly.", d => s_assemblyDirectory = d },
            {
                "?|h|help", "Shows a list of available commands.", h =>
                {
                    if (h == null)
                    {
                        return;
                    }

                    ShowHelp();
                    s_help = true;
                }
            },
            { "i|procedureId=", "The ID of the control procedure to run.", i => s_procedureId = i },
            {
                "o|online", "The control and measurement process can be controlled externally via Web API.", o =>
                {
                    if (o != null)
                    {
                        s_online = true;
                    }
                }
            },
            { "p|procedure=", "The name of the control procedure to run.", p => s_procedureName = p }
        };
    }

    public static CliOptions ParseCliArguments(IEnumerable<string> args)
    {
        OptionSet.Parse(args);
        return new CliOptions(s_configuration, s_procedureName, s_procedureId, s_assemblyName, s_assemblyDirectory, s_online, s_help);
    }

    private static void ShowHelp()
    {
        OptionSet.WriteOptionDescriptions(Console.Out);
    }
}

public class CliOptions
{
    public readonly string AssemblyDirectory;
    public readonly string AssemblyName;
    public readonly string Configuration;
    public readonly bool IsOnline;
    public readonly string ProcedureId;
    public readonly string ProcedureName;
    public readonly bool ShowHelp;

    public CliOptions(string configuration, string procedureName, string procedureId, string assemblyName, string assemblyDirectory, bool online, bool help)
    {
        Configuration = configuration;
        ProcedureName = procedureName;
        ProcedureId = procedureId;
        AssemblyName = assemblyName;
        AssemblyDirectory = assemblyDirectory;
        IsOnline = online;
        ShowHelp = help;
    }
}
