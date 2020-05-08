﻿using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Yandex_practice.WrapperFactory
{
    public class WebDriverFactory
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        private static IWebDriver _driver;

        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                    throw new NullReferenceException("The WebDriver browser instance was not initialized." +
                        " You should first call the method InitBrowser.");

                return _driver;
            }
            private set
            {
                _driver = value;
            }
        }

        public static void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Chrome":
                    if (_driver == null)
                    {
                        _driver = new ChromeDriver();
                        Drivers.Add("Chrome", _driver);
                    }

                    break;

                case "Firefox":
                    if (_driver == null)
                    {
                        _driver = new FirefoxDriver();
                        Drivers.Add("Firefox", _driver);
                    }

                    break;

                case "IE":
                    if (_driver == null)
                    {
                        _driver = new InternetExplorerDriver();
                        Drivers.Add("IE", _driver);
                    }

                    break;
            }
        }

        public static void GoToUrl(string url)
        {
            Driver.Url = url;
        }

        public static string GetTitle()
        {
            string Title = _driver.Title;
            return Title;
        }

        public static void BackToPreviousePage()
        {
            _driver.Navigate().Back();
        }

        public static void SwitchToNewWindow()
        {
            string newWindow = _driver.WindowHandles[_driver.WindowHandles.Count - 1].ToString();
            _driver.SwitchTo().Window(newWindow);
        }

        public static void SwitchToOriginalWindow()
        {
            string originalWindow = _driver.WindowHandles[_driver.WindowHandles.Count - 2].ToString();
            _driver.SwitchTo().Window(originalWindow);
        }

        public static void SwitchToRemainingWindow()
        {
            
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
        }

        public static void CloseWindow()
        {
            
            _driver.Close();
        }

        public static void ReloadThePage()
        {

            _driver.Navigate().Refresh();
        }

        public static void SwitchToIframe()
        {
            _driver.SwitchTo().Frame(0);
        }       

        public static void CloseAllDrivers()
        {
            foreach (var key in Drivers.Keys)
            {
                Drivers[key].Quit();
            }

            Drivers.Clear();
            _driver = default;
        }
    }
}
