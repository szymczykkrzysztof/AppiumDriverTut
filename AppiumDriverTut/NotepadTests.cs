using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System.Diagnostics;

namespace AppiumDriverTut
{
    [TestFixture]
    public class NotepadTests
    {
        private WindowsDriver _driver;
        private Process _wadProcess;
        private Process _appiumProcess;
        
        [OneTimeSetUp]
        public void StartServers()
        {
            _wadProcess = new Process();
            _wadProcess.StartInfo = new ProcessStartInfo
            {
                FileName = @"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe",
                Arguments = "4724",
                UseShellExecute = true,
                Verb = "runas" 
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
            Thread.Sleep(5000);

        }
        [SetUp]
        public void Setup()
        {
            var options = new AppiumOptions
            {
                PlatformName = "Windows",
                AutomationName = "Windows",
                App = @"C:\Windows\System32\notepad.exe"
            };

            _driver = new WindowsDriver(
                new Uri("http://127.0.0.1:4723"),
                options,
                TimeSpan.FromSeconds(60));

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void SendTextTest()
        {
            var txtField = _driver.FindElement(
                MobileBy.ClassName("RichEditD2DPT"));
            txtField.SendKeys("Hello from Appium!");
            Assert.That(txtField.Text, Contains.Substring("Hello from Appium!"));
            for (var i = 0; i < "Hello from Appium!".Length; i++)
            {
                txtField.SendKeys(Keys.Backspace);
            }
           
        }
        [Test]
        public void SendAnotherTextTest()
        {
            var txtField = _driver.FindElement(
                MobileBy.ClassName("RichEditD2DPT"));
            txtField.SendKeys("Hello from Another Appium!");
            Assert.That(txtField.Text, Contains.Substring("Hello from Another Appium!"));
            for (var i = 0; i < "Hello from Another Appium!".Length; i++)
            {
                txtField.SendKeys(Keys.Backspace);
            }

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
            _wadProcess.Kill();
            _appiumProcess.Kill();

            foreach (var process in Process.GetProcessesByName("WinAppDriver"))
                process.Kill();
            foreach (var process in Process.GetProcessesByName("node"))
                process.Kill();
            _wadProcess.Dispose();
            _appiumProcess.Dispose();
        }
    }
}
