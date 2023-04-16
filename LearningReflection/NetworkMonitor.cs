using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace LearningReflection;

public static class NetworkMonitor
{
    private static NetworkMonitorSettings _networkMonitorSettings = new();
    private static Type? _warningServiceType;
    private static MethodInfo? _warningServiceMethod;
    private static List<object> _warningServiceParameterValues = new();
    private static object _warningService;

    public static void Warn()
    {
        if (_warningService is null)
        {
            _warningService = Activator.CreateInstance(_warningServiceType);
        }

        var parameters = _networkMonitorSettings.PropertyBag.Cast<object>().ToList();

        _warningServiceMethod?.Invoke(_warningService, _warningServiceParameterValues.ToArray());
    }

    public static void BootstrapFromConfiguration()
    {
        var appSettingsConfiguration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, true)
            .Build();

        appSettingsConfiguration.Bind("NetworkMonitorSettings", _networkMonitorSettings);

        _warningServiceType = Assembly.GetExecutingAssembly().GetType(_networkMonitorSettings.WarningService);

        if (_warningServiceType is null)
        {
            throw new Exception("Invalid configuration - Service.");
        }

        _warningServiceMethod = _warningServiceType.GetMethod(_networkMonitorSettings.MethodToExecute);

        if (_warningServiceMethod is null)
        {
            throw new Exception("Invalid configuration - Method.");
        }

        foreach (var parameterInfo in _warningServiceMethod.GetParameters())
        {
            if (!_networkMonitorSettings.PropertyBag.TryGetValue(
                    parameterInfo.Name, out object parameterValue))
            {
                throw new Exception($"Invalid configuration - Parameter {parameterInfo.Name}");
            }

            try
            {
                var typedValue = Convert.ChangeType(parameterValue, parameterInfo.ParameterType);
                _warningServiceParameterValues.Add(typedValue);
            }
            catch
            {
                throw new Exception($"Invalid configuration - Parameter {parameterInfo.Name}");
            }
        }
    }
}