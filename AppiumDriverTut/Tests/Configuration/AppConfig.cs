namespace AppiumDriverTut.Tests.Configuration;

public class AppConfig(string appPath)
{
    public string AppPath { get; init; } = appPath;
    public int DriverTimeoutSeconds { get; init; } = 60;
}