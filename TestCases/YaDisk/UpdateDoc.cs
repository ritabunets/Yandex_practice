using NUnit.Framework;
using Yandex_practice.PageObjects;
using Yandex_practice.TestConfig;
using Yandex_practice.WrapperFactory;

namespace Yandex_practice.TestCases.YaDisk
{
    class UpdateDoc : BaseTest
    {
        [Test]
        public void UpdateDocument()
        {
            Page.Authentication.LogIn();
            Page.Passport.OpenYaDisk();
            Page.Disk.CreateNewDoc();
            WebDriverFactory.CloseWindow();
            WebDriverFactory.SwitchToRemainingWindow();
            Page.Disk.UpdateDoc();
            WebDriverFactory.CloseWindow();
            WebDriverFactory.SwitchToRemainingWindow();
            string updatedDocContent = Page.Disk.GetUpdatedDoc();
            Assert.AreEqual(Constants.updatedcontent, updatedDocContent);
        }
    }
}
