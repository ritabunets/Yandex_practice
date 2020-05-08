using NUnit.Framework;
using Yandex_practice.PageObjects;
using Yandex_practice.TestConfig;

namespace Yandex_practice.TestCases.Login
{
    class LogInWithoutPassword : BaseTest
    {
        [Test]
        public void LogInWOPassword()
        {
            Page.Authentication.FillInLoginValid();
            Page.Authentication.ClickLogInButton();
            Page.Authentication.ClickLogInButton();
            string ErrorText = Page.Authentication.GetErrorText();
            Assert.AreEqual(Constants.emptypassworderror, ErrorText);
        }
    }
}