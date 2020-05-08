using NUnit.Framework;
using Yandex_practice.PageObjects;
using Yandex_practice.TestConfig;

namespace Yandex_practice.TestCases.Login.OtherControls
{
    class BackControl:BaseTest
    {
        [Test]
        public void CheckBackControl()
        {

            Page.Authentication.FillInLoginValid();
            Page.Authentication.ClickLogInButton();
            Page.Authentication.ClickBackControl();
            string currentValue = Page.Authentication.GetLoginInputValue();
            Assert.AreEqual(Constants.login, currentValue);
        }
    }
}
