using DotNetFiddleUIAutomation.Helpers;
using OpenQA.Selenium;
using System.Threading;

namespace DotNetFiddleUIAutomation.Pages
{
    public class NugetPackagePage
    {
        static IWebDriver driver = BaseTest.getInstance();

        //Page elements initialization
        protected IWebElement NugetPackageTextBox = driver.FindElement(By.XPath("//input[@class='new-package form-control input-sm']"));

        public void AddNugetPackage(string package)
        {
            //Wait for Nuget Package TextBox to be displayed and enter package name
            Utilities.GetElementByXpathWhenReady("//input[@class='new-package form-control input-sm']", 5); 
            NugetPackageTextBox.Clear();
            NugetPackageTextBox.SendKeys(package);
            
            //Wait for searched nuget package to be displayed and select the package
            Utilities.GetElementByXpathWhenReady("//li[@class='ui-menu-item']/a[@class='ui-corner-all']", 5);
            IWebElement NugetPackageSearchedValue = driver.FindElement(By.XPath("//li[@class='ui-menu-item']/a[@class='ui-corner-all']"));            
            NugetPackageSearchedValue.Click();
            Thread.Sleep(5000);

            Utilities.GetElementByXpathWhenReady("//li[@class='ui-menu-item']/ul/li[1]", 5);
            IWebElement NugetPackageVersion = driver.FindElement(By.XPath("//li[@class='ui-menu-item']/ul/li[1]"));
            NugetPackageVersion.Click();
            
        }

        public bool VerifyNugetPackageHasBeenAdded()
        {
            //Wait for the selected nuget package 
            Utilities.GetElementByXpathWhenReady("//div[@class='package-name']", 10);
            IWebElement InstalledNugetPackage = driver.FindElement(By.XPath("//div[@class='package-name']"));

            //Verify if the package has been added successfully
            if (InstalledNugetPackage.Displayed && InstalledNugetPackage.Text.Equals("Superwalnut.NetCoreApiTemplate"))
                return true;
            else
                return false;
        }
    }
}
