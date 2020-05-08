using NUnit.Framework;
using Yandex_practice.PageObjects;
using Yandex_practice.TestConfig;

namespace Yandex_practice.TestCases.Login
{
    class LogInWithInvalidLogin : BaseTest
    {
        [Test]
        public void LogInWInvalidLogin()

        {
            Page.Authentication.FillInLoginInvalid();
            Page.Authentication.ClickLogInButton();
            string ErrorText = Page.Authentication.GetErrorText();
            Assert.AreEqual(Constants.invalidloginerror, ErrorText);           
        }
    }
}