using AppiumDriverTut.Tests.Configration;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System.Diagnostics;
using AppiumDriverTut.Tests.Configuration;

namespace AppiumDriverTut.Tests
{
    [TestFixture]
    public class NotepadTests:AppTestBase
    {
        protected override AppConfig GetAppConfig() => new()
        {
            AppPath = @"C:\Windows\System32\notepad.exe",
            DriverTimeoutSeconds = 60
        };

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
        [Test]
        public void SendAnotherAnotherTextTest()
        {
            var txtField = _driver.FindElement(
                MobileBy.ClassName("RichEditD2DPT"));
            txtField.SendKeys("Hello from Another Another Appium!");
            Assert.That(txtField.Text, Contains.Substring("Hello from Another Another Appium!"));
            for (var i = 0; i < "Hello from Another Another Appium!".Length; i++)
            {
                txtField.SendKeys(Keys.Backspace);
            }

        }
    }
}
