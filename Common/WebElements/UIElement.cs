using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using Yandex_practice.Common.Enums;
using Yandex_practice.Common.Extensions;
using Yandex_practice.WrapperFactory;

namespace Yandex_practice.Common.WebElements
{
    public class UIElement : IWebElement
    {
        private IWebElement _webElement
        {
            get
            {
                return WebDriverFactory.Driver.GetElementWhenExists(Locator);
            }

        }

        public By Locator { get; set; }

        public UIElement(FindBy by, string locator)
        {
            switch (by)
            {
                case FindBy.XPath:
                    Locator = By.XPath(locator);
                    break;
                case FindBy.Css:
                    Locator = By.CssSelector(locator);
                    break;
                case FindBy.Id:
                    Locator = By.Id(locator);
                    break;
                case FindBy.ClassName:
                    Locator = By.ClassName(locator);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(by));
            }
        }

        public string TagName => throw new NotImplementedException();       

        public string Text => _webElement.Text;

        public bool Enabled => _webElement.Enabled;

        public bool Selected => _webElement.Selected;

        public Point Location => _webElement.Location;

        public Size Size => _webElement.Size;
        
        public bool Displayed => _webElement.Displayed;

        public void Clear() => _webElement.SendKeys(Keys.Control + "A" + Keys.Delete); 

        public void Click() => _webElement.Click();

        public IWebElement FindElement(By by)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            throw new NotImplementedException();
        }
      
        public string GetAttribute(string attributeName) => _webElement.GetAttribute(attributeName);

        public string GetCssValue(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public void SendKeys(string text) => _webElement.SendKeys(text);
        
        public void Submit()
        {
            throw new NotImplementedException();
        }
    }
}
