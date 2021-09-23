using autotests.Drivers;
using autotests.Page;
using NUnit.Framework;
using OpenQA.Selenium;
namespace autotests.Test
{
    public class BaseTest
    {
        protected static IWebDriver driver;
        public static TestPage testPage;
        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            driver = CustomDriver.GetChrome();
            testPage = new TestPage(driver);
        }
        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            driver.Quit();
        }
    }
}