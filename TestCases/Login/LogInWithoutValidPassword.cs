using NUnit.Framework;
using Yandex_practice.PageObjects;
using Yandex_practice.TestConfig;

namespace Yandex_practice.TestCases.Login
{
    class LogInWithInvalidPassword : BaseTest
    {
        [Test]
        public void LogInWInvalidPassword()

        {
            Page.Authentication.FillInLoginValid();
            Page.Authentication.ClickLogInButton();
            Page.Authentication.FillInPasswordInvalid();
            Page.Authentication.ClickLogInButton();
            string ErrorText = Page.Authentication.GetErrorText();
            Assert.AreEqual(Constants.invalidpassworderror, ErrorText);
        }
    }
    
}


