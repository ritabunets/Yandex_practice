using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Yandex_practice.Tests.TestConfig;

namespace Yandex_practice.WrapperFactory
{
    public static class WebDriverFactory
    {
        private static ThreadLocal<IWebDriver> _driverThreadLocal;

        public static IWebDriver Driver {
            get
            {
                if (_driverThreadLocal == null)
                {
                    InitBrowser(Constants.browserName);
                }

                return _driverThreadLocal.Value;
            }
        }

        public static void InitBrowser(string browserName)
        {
            if(_driverThreadLocal == null)
            {
                _driverThreadLocal = new ThreadLocal<IWebDriver>();
            }

            switch (browserName)
            {
                case "Chrome":
                    if (_driverThreadLocal.Value == null)
                    {
                        _driverThreadLocal.Value = new ChromeDriver();
                    }

                    break;

                case "Firefox":
                    if (_driverThreadLocal.Value == null)
                    {
                        _driverThreadLocal.Value = new FirefoxDriver();
                    }

                    break;

                case "IE":
                    if (_driverThreadLocal.Value == null)
                    {
                        _driverThreadLocal.Value = new InternetExplorerDriver();
                    }

                    break;
            }
        }

        public static void GoToUrl(string url)
        {
            Driver.Url = url;
        }

        public static void SwitchToNewWindow()
        {
            string newWindow = Driver.WindowHandles[Driver.WindowHandles.Count - 1].ToString();
            Driver.SwitchTo().Window(newWindow);
        }

        public static void SwitchToOriginalWindow()
        {
            string originalWindow = Driver.WindowHandles[Driver.WindowHandles.Count - 2].ToString();
            Driver.SwitchTo().Window(originalWindow);
        }

        public static void SwitchToFirstWindow()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.First());
        }
        
        public static void CloseWindow()
        {
            Driver.Close();
        }

        public static void ReloadThePage()
        {
            Driver.Navigate().Refresh();
        }

        public static void SwitchToIframe()
        {
            Driver.SwitchTo().Frame(0);
        }

        public static void CloseAllDrivers()
        {
            Driver.Quit();
            _driverThreadLocal.Value = null;
        }
    }
}
