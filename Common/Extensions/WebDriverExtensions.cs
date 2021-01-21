using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Yandex_practice.WrapperFactory;

namespace Yandex_practice.Common.Extensions
{
    public static class WebDriverExtensions
    {
        public static IWebElement GetElementWhenExists(this IWebDriver webDriver, By by)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(60));
            wait.Until(x => webDriver.FindElements(by).Count>0);
            return webDriver.FindElement(by);           
        }

        public static void ConfirmElementDisplayed(this IWebDriver webDriver, IWebElement element)
        {
            try
            {
                var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(60));
                wait.Until(d => element.Displayed);
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"'{element}'was not found");
            }
        }

        public static void ConfirmTextNotNull(this IWebDriver webDriver, IWebElement element)
        {
            try
            {
                var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(60));
                wait.Until(n => element.Text.Length!= 0);
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"'{element}' text was not found");
            }           
        }
        
    }
}
