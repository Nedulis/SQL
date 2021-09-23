using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace autotests.Drivers
{
    public class CustomDriver
    {
        public static IWebDriver GetChrome()
        {
            return GetDriver(Browsers.Chrome);
        }
        private static IWebDriver GetDriver(Browsers webDriver)
        {
            IWebDriver driver = null;
            switch (webDriver)
            {
                case Browsers.Chrome:
                    driver = new ChromeDriver();
                    break;
            }
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }
    }
}