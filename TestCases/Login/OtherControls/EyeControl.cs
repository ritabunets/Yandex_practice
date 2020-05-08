using NUnit.Framework;
using Yandex_practice.PageObjects;

namespace Yandex_practice.TestCases.Login.OtherControls
{
    class EyeControl:BaseTest
    {
        [Test]
        public void CheckEyeControl()
        {
            Page.Authentication.FillInLoginValid();
            Page.Authentication.ClickLogInButton();
            Page.Authentication.FillInPasswordValid();
            Page.Authentication.ClickEyeControl();
            string currentType = Page.Authentication.GetPasswordInputType();
            Assert.AreEqual("text", currentType);
        }
    }
}
