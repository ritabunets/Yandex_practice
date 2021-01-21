using System;
using NUnit.Framework;
using Yandex_practice.WrapperFactory;
using Yandex_practice.Tests.TestConfig;
using OpenQA.Selenium;
using NUnit.Framework.Interfaces;
using NLog;

namespace Yandex_practice
{
    [TestFixture]
    public class BaseTest
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        [SetUp]
        public void SetUpTest()
        {
            WebDriverFactory.InitBrowser(Constants.browserName);
            WebDriverFactory.GoToUrl(Constants.url);
            WebDriverFactory.Driver.Manage().Window.Maximize();
            WebDriverFactory.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
                   
        [TearDown]
        public void OneTimeTearDownTest()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                Screenshot screenshot = ((ITakesScreenshot)WebDriverFactory.Driver).GetScreenshot();
                string filePath = $"{Constants.screenshotdirectory}{DateTime.Now.ToString("yyyyMMdd_HHmm_")}_" + $"{TestContext.CurrentContext.Test.Name}.png";
                screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
                logger.Error(TestContext.CurrentContext.Result.Message);
                TestContext.AddTestAttachment(filePath);
            }
            WebDriverFactory.CloseAllDrivers();
        }

    }
}
