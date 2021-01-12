using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNetFiddleUIAutomation.Pages;

namespace DotNetFiddleUIAutomation
{
    [TestClass]
    public class UnitTest1 : BaseTest
    {
        private TestContext testContextInstance;
        HomePage homePage;
        NugetPackagePage nugetPackagePage;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value;  }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            base.UITestInitialize(TestContext);
            homePage = new HomePage();
            nugetPackagePage = new NugetPackagePage();
        }

        [ClassCleanup]
        public static void TestClassCleanUp()
        {
            BaseTest.UIClassCleanUp();
        }

        //TestCase1
        [TestMethod]

        public void VerifyRunFunctionality()
        {
            //Click on the run button
            homePage.ClickRun();

            //Verify output in poutput window
            Assert.IsTrue(homePage.VerifyOutput(), "'Hello World' Output is not displayed");
        }

        //TestCase2
        [TestMethod]
        public void VerifyAddNugetPackageFunctionality()
        {
            //Select nUnit NugetPackage
            nugetPackagePage.AddNugetPackage("nUnit(3.12.0)");

            //Verify Nuget Package Has been added successfully
            Assert.IsTrue(nugetPackagePage.VerifyNugetPackageHasBeenAdded(), "'Nuget Package Has not been added successfully");
        }

    }
}
