using NUnit.Framework;
using Yandex_practice.PageObjects;

namespace Yandex_practice.TestCases.Login.OtherControls
{
    class ForgotLoginLink : BaseTest
    {
        [Test]
        public void CheckForgotLoginLink()
        {
            Page.Authentication.FollowForgotLoginLink();
            bool isForgotLoginFormDisplayed = Page.Authentication.GetForgotLoginForm();
            Assert.AreEqual(true, isForgotLoginFormDisplayed);
        }

    }

}