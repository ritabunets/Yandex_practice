using OpenQA.Selenium;
using Yandex_practice.WrapperFactory;

namespace Yandex_practice.Common.Extensions
{
    public static class WebElementExtensions
    {
        public static void ConfirmElementDisplayed(this IWebElement element)
        {
            WebDriverFactory.Driver.ConfirmElementDisplayed(element);
        }
        
        public static void ConfirmTextNotNull(this IWebElement element)
        {
            WebDriverFactory.Driver.ConfirmTextNotNull(element);
        }        

    }
}

