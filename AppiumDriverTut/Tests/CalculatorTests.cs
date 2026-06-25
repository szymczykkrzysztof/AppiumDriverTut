using AppiumDriverTut.Tests.Configration;
using AppiumDriverTut.Tests.Configuration;
using OpenQA.Selenium.Appium;

namespace AppiumDriverTut.Tests
{
    public class CalculatorTests : AppTestBase
    {
        protected override AppConfig GetAppConfig() => new()
        {
            AppPath = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App",
            DriverTimeoutSeconds = 60
        };

        [Test]
        public void AddTwoNumbersTest()
        {
            var btn8 = _driver.FindElement(MobileBy.AccessibilityId("num8Button"));
            btn8.Click();
            var btnPlus = _driver.FindElement(MobileBy.AccessibilityId("plusButton"));
            btnPlus.Click();
            btn8.Click();
            var btnEqual = _driver.FindElement(MobileBy.AccessibilityId("equalButton"));
            btnEqual.Click();
            var result = _driver.FindElement(MobileBy.AccessibilityId("CalculatorResults"));
            Assert.That(result.Text, Contains.Substring("16"));
        }

        [Test]
        public void SubtractNumbersTest()
        {
            var btn8 = _driver.FindElement(MobileBy.AccessibilityId("num8Button"));
            var btn6 = _driver.FindElement(MobileBy.AccessibilityId("num6Button"));
            var btnEqual = _driver.FindElement(MobileBy.AccessibilityId("equalButton"));
            var btnMinus = _driver.FindElement(MobileBy.AccessibilityId("minusButton"));
            var result = _driver.FindElement(MobileBy.AccessibilityId("CalculatorResults"));
            btn8.Click();
            btnMinus.Click();
            btn6.Click();
            btnEqual.Click();
            
            Assert.That(result.Text, Contains.Substring("2"));
        }
        [Test]
        public void MultiplyNumbersTest()
        {
            var btn8 = _driver.FindElement(MobileBy.AccessibilityId("num8Button"));
            var btn5 = _driver.FindElement(MobileBy.AccessibilityId("num5Button"));
            var btnEqual = _driver.FindElement(MobileBy.AccessibilityId("equalButton"));
            var btnMultiply = _driver.FindElement(MobileBy.AccessibilityId("multiplyButton"));
            var result = _driver.FindElement(MobileBy.AccessibilityId("CalculatorResults"));
            btn8.Click();
            btnMultiply.Click();
            btn5.Click();
            btnEqual.Click();

            Assert.That(result.Text, Contains.Substring("40"));
        }
        [Test]
        public void DivideNumbersTest()
        {
            var btn8 = _driver.FindElement(MobileBy.AccessibilityId("num8Button"));
            var btn4 = _driver.FindElement(MobileBy.AccessibilityId("num4Button"));
            var btnEqual = _driver.FindElement(MobileBy.AccessibilityId("equalButton"));
            var btnDivide = _driver.FindElement(MobileBy.AccessibilityId("divideButton"));
            var result = _driver.FindElement(MobileBy.AccessibilityId("CalculatorResults"));
            btn8.Click();
            btnDivide.Click();
            btn4.Click();
            btnEqual.Click();

            Assert.That(result.Text, Contains.Substring("2"));
        }
    }
}
