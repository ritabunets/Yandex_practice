using NUnit.Framework;
using Yandex_practice.PageObjects;
using Yandex_practice.Tests.TestConfig;

namespace Yandex_practice.Tests.TestCases.Login.OtherControls
{
    [TestFixture]

    [Parallelizable(ParallelScope.All)]
    class OtherControls : BaseTest
    {
        private readonly string registrationPageTitle = "Регистрация";

        private readonly string vk = "vk";
        private readonly string fb = "fb";
        private readonly string gg = "gg";
        private readonly string mr = "mr";
        private readonly string ok = "ok";
        private readonly string tw = "tw";

        [Test]
        public void CheckBackControl()
        {
            Page.Authentication.FillInLoginInput(Constants.login);
            Page.Authentication.ClickLogInButton();
            string loginCurrentValue = Page.Authentication.ClickBackControl();
            Assert.AreEqual(Constants.login, loginCurrentValue,
                 $"Unexpected login value. Expected: {Constants.login}, Actual: {loginCurrentValue}.");
        }

        [Test]
        public void CheckCurrentAccountControl()
        {
            Page.Authentication.FillInLoginInput(Constants.login);
            Page.Authentication.ClickLogInButton();
            string loginCurrentValue = Page.Authentication.ClickCurrentAccountControl();
            Assert.AreEqual(string.Empty, loginCurrentValue,
                  $"Unexpected login value. Expected: Empty, Actual: {loginCurrentValue}.");
        }

        [Test]
        public void CheckEyeControl()
        {
            Page.Authentication.FillInLoginInput(Constants.login);
            Page.Authentication.ClickLogInButton();
            Page.Authentication.FillInPasswordInput(Constants.password);
            string passwordCurrentType = Page.Authentication.ClickEyeControl();
            Assert.AreEqual("text", passwordCurrentType,
                  $"Unexpected password input type. Expected: text, Actual: {passwordCurrentType}.");
        }

        [Test]
        public void CheckFogotPasswordForm()
        {
            Page.Authentication.FillInLoginInput(Constants.login);
            Page.Authentication.ClickLogInButton();
            bool isForgotPasswordFormAvailable = Page.Authentication.NavigateForgotPasswordForm();
            Assert.IsTrue(isForgotPasswordFormAvailable);
        }

        [Test]
        public void CheckForgotLoginLink()
        {
            bool isForgotLoginFormAvailable = Page.Authentication.NavigateForgotLoginForm();
            Assert.IsTrue(isForgotLoginFormAvailable);
        }

        [Test]
        public void CheckQrCodeButton()
        {
            bool isQrCodeFormDisplayed = Page.Authentication.ClickQrCodeButton();
            Assert.IsTrue(isQrCodeFormDisplayed);
        }               

        [Test]
        public void CheckRegistationButton()
        {
            string currentTitle = Page.Authentication.NavigateRegistationPage();
            Assert.AreEqual(registrationPageTitle, currentTitle,
                $"Unexpected page title. Expected: {registrationPageTitle}, Actual: {currentTitle}.");
        }              

        [Test]
        public void CheckSocialNetworksControls()
        {
            bool isVkIconDisplayed = Page.Authentication.GetPrimarySocial(vk);
            bool isFacebookIconDisplayed = Page.Authentication.GetPrimarySocial(fb);
            bool isGoogleIconDisplayed = Page.Authentication.GetPrimarySocial(gg);
            Page.Authentication.GetSecondarySocialNetworks();
            bool isMailRuIconDisplayed = Page.Authentication.GetSecondarySocial(mr);
            bool isOkIconDisplayed = Page.Authentication.GetSecondarySocial(ok);
            bool isTwitterIconDisplayed = Page.Authentication.GetSecondarySocial(tw);

            Assert.Multiple(
                () =>
                {
                    Assert.IsTrue(isVkIconDisplayed);
                    Assert.IsTrue(isFacebookIconDisplayed);
                    Assert.IsTrue(isGoogleIconDisplayed);
                    Assert.IsTrue(isMailRuIconDisplayed);
                    Assert.IsTrue(isOkIconDisplayed);
                    Assert.IsTrue(isTwitterIconDisplayed);
                });

        }

    }
}
