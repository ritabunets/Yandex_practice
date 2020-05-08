using NUnit.Framework;
using Yandex_practice.PageObjects;

namespace Yandex_practice.TestCases.Login.OtherControls
{
    class QrCodeButton : BaseTest
    {
        [Test]
        public void CheckQrCodeButton()
        {
            Page.Authentication.ClickQrCodeButton();
            bool isQrCodeFormDisplayed = Page.Authentication.GetQrCodeForm();
            Assert.AreEqual(true, isQrCodeFormDisplayed);
        }

    }

}