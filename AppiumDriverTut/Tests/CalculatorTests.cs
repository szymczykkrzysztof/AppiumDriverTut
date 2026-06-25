
using AppiumDriverTut.Tests.Configuration;
using OpenQA.Selenium.Appium;

namespace AppiumDriverTut.Tests
{
    public class CalculatorTests : AppTestBase
    {
        protected override AppConfig GetAppConfig() => new("Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");

        [Test]
        public void AddTwoNumbersTest()
        {
            var btn8 = Driver.FindElement(MobileBy.AccessibilityId("num8Button"));
            btn8.Click();
            var btnPlus = Driver.FindElement(MobileBy.AccessibilityId("plusButton"));
            btnPlus.Click();
            btn8.Click();
            var btnEqual = Driver.FindElement(MobileBy.AccessibilityId("equalButton"));
            btnEqual.Click();
            var result = Driver.FindElement(MobileBy.AccessibilityId("CalculatorResults"));
            Assert.That(result.Text, Contains.Substring("16"));
        }

        [Test]
        public void SubtractNumbersTest()
        {
            var btn8 = Driver.FindElement(MobileBy.AccessibilityId("num8Button"));
            var btn6 = Driver.FindElement(MobileBy.AccessibilityId("num6Button"));
            var btnEqual = Driver.FindElement(MobileBy.AccessibilityId("equalButton"));
            var btnMinus = Driver.FindElement(MobileBy.AccessibilityId("minusButton"));
            var result = Driver.FindElement(MobileBy.AccessibilityId("CalculatorResults"));
            btn8.Click();
            btnMinus.Click();
            btn6.Click();
            btnEqual.Click();
            
            Assert.That(result.Text, Contains.Substring("2"));
        }
        [Test]
        public void MultiplyNumbersTest()
        {
            var btn8 = Driver.FindElement(MobileBy.AccessibilityId("num8Button"));
            var btn5 = Driver.FindElement(MobileBy.AccessibilityId("num5Button"));
            var btnEqual = Driver.FindElement(MobileBy.AccessibilityId("equalButton"));
            var btnMultiply = Driver.FindElement(MobileBy.AccessibilityId("multiplyButton"));
            var result = Driver.FindElement(MobileBy.AccessibilityId("CalculatorResults"));
            btn8.Click();
            btnMultiply.Click();
            btn5.Click();
            btnEqual.Click();

            Assert.That(result.Text, Contains.Substring("40"));
        }
        [Test]
        public void DivideNumbersTest()
        {
            var btn8 = Driver.FindElement(MobileBy.AccessibilityId("num8Button"));
            var btn4 = Driver.FindElement(MobileBy.AccessibilityId("num4Button"));
            var btnEqual = Driver.FindElement(MobileBy.AccessibilityId("equalButton"));
            var btnDivide = Driver.FindElement(MobileBy.AccessibilityId("divideButton"));
            var result = Driver.FindElement(MobileBy.AccessibilityId("CalculatorResults"));
            btn8.Click();
            btnDivide.Click();
            btn4.Click();
            btnEqual.Click();

            Assert.That(result.Text, Contains.Substring("2"));
        }
    }
}
