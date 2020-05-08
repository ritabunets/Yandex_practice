using NUnit.Framework;
using Yandex_practice.PageObjects;
using Yandex_practice.WrapperFactory;

namespace Yandex_practice.TestCases.YaDisk
{
    class CreateNewWordDoc : BaseTest
    {
        [Test]
        public void AddNewDocument()
        {
            Page.Authentication.LogIn();
            Page.Passport.OpenYaDisk();
            Page.Disk.CreateNewFolder();
            Page.Disk.NavigateNewFolder();
            Page.Disk.CreateNewDoc();
            WebDriverFactory.SwitchToOriginalWindow();
            bool isNewDocDisplayed = Page.Disk.GetNewDoc();
            Assert.AreEqual(true, isNewDocDisplayed);
        }
    }
}
