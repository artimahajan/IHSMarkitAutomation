using OpenQA.Selenium;
using DotNetFiddleUIAutomation.Helpers;

namespace DotNetFiddleUIAutomation.Pages
{
    public class HomePage
    {
        static IWebDriver driver = BaseTest.getInstance();

        //Page elements initialization
        protected IWebElement RunButton = driver.FindElement(By.XPath("//button[@id='run-button']"));
        protected IWebElement OutputWindow = driver.FindElement(By.XPath("//div[@id='output']"));

        //Method to click on the run button
        public void ClickRun()
        {
            Utilities.GetElementByXpathWhenReady("//button[@id='run-button']", 5);
            RunButton.Click();
        }

        //Verify the output in Output Window
        public bool VerifyOutput()
        {
            if (OutputWindow.Text.Equals("Hello World"))
                return true;
            else
                return false;
        }
    }

    
}
