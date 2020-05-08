using System;
using Yandex_practice.WrapperFactory;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Community.PageObjects;
using Yandex_practice.TestConfig;
using OpenQA.Selenium.Support.UI;

namespace Yandex_practice.PageObjects
{
    public class PassportPage
    {
        [FindsBy(how: How.XPath, @using: "//a[@href='/profile/services']")]
        private IWebElement _myServices;

        [FindsBy(how: How.XPath, @using: "//a[contains(text(),'Диск')]")]
        private IWebElement _yaDisk;


        public void OpenYaDisk()
        {
            _myServices.Click();
            WebDriverFactory.ReloadThePage();
            _yaDisk.Click();
        }

    }
}
