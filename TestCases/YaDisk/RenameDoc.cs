using NUnit.Framework;
using Yandex_practice.PageObjects;
using Yandex_practice.WrapperFactory;

namespace Yandex_practice.TestCases.YaDisk
{
    class RenameDoc : BaseTest
    {
        [Test]
        public void AddNewDocument()
        {
            Page.Authentication.LogIn();
            Page.Passport.OpenYaDisk();
            Page.Disk.CreateNewDoc();
            WebDriverFactory.CloseWindow();
            WebDriverFactory.SwitchToRemainingWindow();
            Page.Disk.RenameDoc();
            bool isRenamedDocDisplayed = Page.Disk.GetRenamedDoc();
            Assert.AreEqual(true, isRenamedDocDisplayed);
        }
    }
}
