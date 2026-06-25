using System.Diagnostics;
using AppiumDriverTut.Tests.Configration;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace AppiumDriverTut.Tests.Configuration;

public abstract class AppTestBase
{
    protected WindowsDriver _driver;
    private Process _wadProcess;
    private Process _appiumProcess;
    protected abstract AppConfig GetAppConfig();
        
    [OneTimeSetUp]
    public void StartServers()
    {
        var config = GetAppConfig();

        _wadProcess = new Process();
        _wadProcess.StartInfo = new ProcessStartInfo
        {
            FileName = @"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe",
            Arguments = "4724",
            UseShellExecute = true
        };
        _wadProcess.Start();

        _appiumProcess = new Process();
        _appiumProcess.StartInfo = new ProcessStartInfo
        {
            FileName = "appium",
            Arguments = "--port 4723",
            UseShellExecute = true
        };
        _appiumProcess.Start();

        WaitForPort(4724, "WinAppDriver");
        WaitForPort(4723, "Appium");
    }

    [SetUp]
    public void Setup()
    {
        var config = GetAppConfig();

        var options = new AppiumOptions
        {
            PlatformName = "Windows",
            AutomationName = "Windows",
            App = config.AppPath
        };

        _driver = new WindowsDriver(
            new Uri("http://127.0.0.1:4723"),
            options,
            TimeSpan.FromSeconds(config.DriverTimeoutSeconds));

        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    [TearDown]
    public void Cleanup()
    {
        _driver.Quit();
        _driver.Dispose();
    }

    [OneTimeTearDown]
    public void StopServers()
    {
        _wadProcess?.Kill();
        _appiumProcess?.Kill();

        foreach (var p in Process.GetProcessesByName("WinAppDriver")) p.Kill();
        foreach (var p in Process.GetProcessesByName("node")) p.Kill();

        _wadProcess?.Dispose();
        _appiumProcess?.Dispose();
    }

    private void WaitForPort(int port, string name, int timeoutSeconds = 30)
    {
        var deadline = DateTime.Now.AddSeconds(timeoutSeconds);
        while (DateTime.Now < deadline)
        {
            try
            {
                using var client = new System.Net.Sockets.TcpClient();
                client.Connect("127.0.0.1", port);
                Console.WriteLine($"{name} ready on port {port}");
                return;
            }
            catch
            {
                Thread.Sleep(500);
            }
        }
        throw new Exception($"{name} did not start within {timeoutSeconds}s on port {port}");
    }
}