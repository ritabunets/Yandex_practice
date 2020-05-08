using NUnit.Framework;
using Yandex_practice.PageObjects;

namespace Yandex_practice.TestCases.Login.OtherControls
{
    class FogotPasswordLink : BaseTest
    {
        [Test]
        public void CheckFogotPasswordLink()
        {
            Page.Authentication.FillInLoginValid();
            Page.Authentication.ClickLogInButton();
            Page.Authentication.FollowFogotPasswordLink();
            bool isForgotpasswordFormDisplayed = Page.Authentication.GetForgotPasswordForm();
            Assert.AreEqual(true, isForgotpasswordFormDisplayed);
        }
    }
}
