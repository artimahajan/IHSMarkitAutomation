using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DotNetFiddleUIAutomation.Helpers
{
    public class Utilities
    {
        static IWebDriver driver = BaseTest.getInstance();       
        public static IWebElement GetElementByXpathWhenReady(string xPath, int timeSpan)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSpan));
            wait.Until(driver =>
            {
                IWebElement element = driver.FindElement(By.XPath(xPath));    
                return element.Displayed && element.Enabled;
            });
            return driver.FindElement(By.XPath(xPath));
        }
    }
}
