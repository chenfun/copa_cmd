using Microsoft.Extensions.Logging;

public static class LoggerHelper
{
    private static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddConsole();
    });

    public static ILogger GetLogger<T>()
    {
        return _loggerFactory.CreateLogger<T>();
    }

    public static ILogger GetLogger(string name)
    {
        return _loggerFactory.CreateLogger(name);
    }
}