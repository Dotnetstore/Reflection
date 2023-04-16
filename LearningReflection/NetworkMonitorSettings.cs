namespace LearningReflection;

public class NetworkMonitorSettings
{
    public string WarningService { get; set; }

    public string MethodToExecute { get; set; }

    public Dictionary<string, object> PropertyBag { get; set; } = new(StringComparer.OrdinalIgnoreCase);
}