using Yandex_practice.WrapperFactory;
using Yandex_practice.Common.WebElements;
using NLog;

namespace Yandex_practice.PageObjects
{
    public class PassportPage
    {
        private UIElement _yaDisk = new UIElement(Common.Enums.FindBy.XPath, "//a[contains(text(),'Диск')]");

        private UIElement _myServices = new UIElement(Common.Enums.FindBy.XPath, "//a[@href='/profile/services']");

        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        public void OpenYaDisk()
        {
            logger.Debug("Open Yandex Disk");
            _myServices.Click();
            WebDriverFactory.ReloadThePage();
            _yaDisk.Click();
        }

    }
}
