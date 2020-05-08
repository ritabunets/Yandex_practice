using NUnit.Framework;
using Yandex_practice.PageObjects;
using Yandex_practice.WrapperFactory;

namespace Yandex_practice.TestCases.YaDisk
{
    class RemoveDoc : BaseTest
    {
        [Test]
        public void AddNewDocument()
        {
            Page.Authentication.LogIn();
            Page.Passport.OpenYaDisk();
            Page.Disk.CreateNewDoc();
            WebDriverFactory.CloseWindow();
            WebDriverFactory.SwitchToRemainingWindow();
            Page.Disk.RemoveDoc();
            bool isNewDocEx = Page.Disk.IsDocExist();
            Assert.AreEqual(false, isNewDocEx);
        }
    }

}
