using NUnit.Framework;
using Yandex_practice.PageObjects;
using Yandex_practice.WrapperFactory;
using Yandex_practice.TestConfig;

namespace Yandex_practice.TestCases.Login.OtherControls
{
    class RegistarionButton : BaseTest
    {
        [Test]
        public void CheckRegistationButton()
        {
            Page.Authentication.ClickRegistationButton();
            string currentTitle = WebDriverFactory.GetTitle();
            Assert.AreEqual(Constants.registrationpagetitle, currentTitle);            
        }

    }

}