﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DotNetFiddleUIAutomation
{
    [TestClass]
    public class BaseTest
    {
        private static IWebDriver chromeDriver = getInstance();

        public static IWebDriver getInstance()
        {
            if (chromeDriver == null)
            {
                chromeDriver = SetWebDriver("ch");
            }
            return chromeDriver;
        }
        public static IWebDriver SetWebDriver(string driverType)
        {
            if (driverType == "ch" || driverType == "chrome")
            {
                ChromeOptions options = new ChromeOptions();
                string user = Environment.UserName;
                options.AddUserProfilePreference("download.default_directory", @"C:\Users\arati\Desktop\IHS Markit\DotNetFiddleUIAutomation");
                options.AddUserProfilePreference("download.prompt_for_download", false);
                try
                {
                    chromeDriver = new ChromeDriver(@"C:\Users\arati\Desktop\IHS Markit\DotNetFiddleUIAutomation", options);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message + ex.StackTrace + ex.Source);
                }
            }

            return chromeDriver;
        }

        //Initialize 
        public void UITestInitialize(TestContext testContext)
        {
            chromeDriver.Navigate().GoToUrl("https://dotnetfiddle.net/"); ;
            chromeDriver.Manage().Window.Maximize();  
        }

        //Close and quit browser window
        public static void UIClassCleanUp()
        {
            Console.WriteLine("<<<<Invoked Class Clean up>>>>");
            chromeDriver.Close();
            chromeDriver.Quit();
        }
    }
}
