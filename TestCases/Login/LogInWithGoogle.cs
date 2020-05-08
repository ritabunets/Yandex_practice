using NUnit.Framework;
using Yandex_practice.PageObjects;
using Yandex_practice.TestConfig;

namespace Yandex_practice.TestCases.Login
{
    class LogInWithGoogle : BaseTest
    {
        [Test]
        public void LogInWGoogleAccount()
        {
            Page.Authentication.LogInWithGoogle();
            string PersonalInfoFirstName = Page.Authentication.GetPersonalInfoFirstName();
            Assert.AreEqual(Constants.firstname, PersonalInfoFirstName);
            string PersonalInfoLastName = Page.Authentication.GetPersonalInfoLastName();
            Assert.AreEqual(Constants.lastname, PersonalInfoLastName);
        }
    }
}