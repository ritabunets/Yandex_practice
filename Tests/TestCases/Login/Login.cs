using NUnit.Framework;
using Yandex_practice.PageObjects;
using Yandex_practice.Tests.TestData;
using Yandex_practice.Tests.TestConfig;

namespace Yandex_practice.Tests.TestCases.Login
{
    [TestFixture]

    [Parallelizable(ParallelScope.All)]
    class Login: BaseTest
    {
        [Test]
        public void LogInUsingYandexAccount()
        {
            Page.Authentication.FillInLoginInput(Constants.login);
            Page.Authentication.ClickLogInButton();
            Page.Authentication.FillInPasswordInput(Constants.password);
            Page.Authentication.ClickLogInButton();
            string PersonalInfo = Page.Authentication.GetPersonalInfo();
            Assert.AreEqual(OtherConstants.personalinfo, PersonalInfo,
                $"Unexpected personal info. Expected: {OtherConstants.personalinfo}, Actual: {PersonalInfo}.");
        }

        [Test]
        public void LogInUsingGoogleAccount()
        {
            Page.Authentication.LogInWithGoogle(Constants.gmail, Constants.password);
            string PersonalInfo = Page.Authentication.GetPersonalInfo();
            Assert.AreEqual(OtherConstants.personalinfo, PersonalInfo,
                $"Unexpected personal info. Expected: {OtherConstants.personalinfo}, Actual: {PersonalInfo}.");
        }

        [Test]
        public void LogInUsingEmptyLogin()
        {
            Page.Authentication.ClickLogInButton();
            string ErrorText = Page.Authentication.GetErrorText();
            Assert.AreEqual(OtherConstants.emptyloginerror, ErrorText,
                 $"Unexpected error text. Expected: {OtherConstants.emptyloginerror}, Actual: {ErrorText}.");
        }

        [Test]
        public void LogInUsingEmptyPassword()
        {
            Page.Authentication.FillInLoginInput(Constants.login);
            Page.Authentication.ClickLogInButton();
            Page.Authentication.ClickLogInButton();
            string ErrorText = Page.Authentication.GetErrorText();
            Assert.AreEqual(OtherConstants.emptypassworderror, ErrorText,
                 $"Unexpected error text. Expected: {OtherConstants.emptypassworderror}, Actual: {ErrorText}.");
        }

        [Test]
        public void LogInUsingInvalidLogin()
        {
            Page.Authentication.FillInLoginInput(Constants.invalidlogin);
            Page.Authentication.ClickLogInButton();
            string ErrorText = Page.Authentication.GetErrorText();
            Assert.AreEqual(OtherConstants.invalidloginerror, ErrorText,
                $"Unexpected error text. Expected: {OtherConstants.invalidloginerror}, Actual: {ErrorText}.");
        }

        [Test]
        public void LogInUsingInvalidPassword()
        {
            Page.Authentication.FillInLoginInput(Constants.login);
            Page.Authentication.ClickLogInButton();
            Page.Authentication.FillInPasswordInput(Constants.invalidpassword);
            Page.Authentication.ClickLogInButton();
            string ErrorText = Page.Authentication.GetErrorText();
            Assert.AreEqual(OtherConstants.invalidpassworderror, ErrorText,
                 $"Unexpected error text. Expected: {OtherConstants.invalidpassworderror}, Actual: {ErrorText}.");
        }
    }  
}
