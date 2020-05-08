using NUnit.Framework;
using Yandex_practice.PageObjects;
using Yandex_practice.TestConfig;

namespace Yandex_practice.TestCases.Login
{
    class LogInWithoutLogin : BaseTest
    {
        [Test]
        public void LogInWOLogin()
        {
            Page.Authentication.ClickLogInButton();
            string ErrorText = Page.Authentication.GetErrorText();
            Assert.AreEqual(Constants.emptyloginerror, ErrorText);
        }
    }
}

