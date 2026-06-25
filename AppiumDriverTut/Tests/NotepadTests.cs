
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using AppiumDriverTut.Tests.Configuration;

namespace AppiumDriverTut.Tests
{
    [TestFixture]
    public class NotepadTests:AppTestBase
    {
        protected override AppConfig GetAppConfig() => new(@"C:\Windows\System32\notepad.exe");
        

        [Test]
        public void SendTextTest()
        {
            var txtField = Driver.FindElement(
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
            var txtField = Driver.FindElement(
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
            var txtField = Driver.FindElement(
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
