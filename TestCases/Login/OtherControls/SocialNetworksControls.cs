using NUnit.Framework;
using Yandex_practice.PageObjects;

namespace Yandex_practice.TestCases.Login.OtherControls
{
    class SocialNetworksControls : BaseTest
    {
        [Test]
        public void CheckSocialNetworksControls()
        {
            bool isVkIconDisplayed = Page.Authentication.GetVkIcon();
            Assert.AreEqual(true, isVkIconDisplayed);
            bool isFacebookIconDisplayed = Page.Authentication.GetFacebookIcon();
            Assert.AreEqual(true, isFacebookIconDisplayed);
            bool isGoogleIconDisplayed = Page.Authentication.GetGoogleIcon();
            Assert.AreEqual(true, isGoogleIconDisplayed);
            Page.Authentication.OpenMoreSocialNetworksControls();
            bool isMailRuIconDisplayed = Page.Authentication.GetMailRuIcon();
            Assert.AreEqual(true, isMailRuIconDisplayed);
            bool isOkIconDisplayed = Page.Authentication.GetOkIcon();
            Assert.AreEqual(true, isOkIconDisplayed);
            bool isTwitterIconDisplayed = Page.Authentication.GetTwitterIcon();
            Assert.AreEqual(true, isTwitterIconDisplayed);
        }
    }
}
