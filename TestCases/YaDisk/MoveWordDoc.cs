using NUnit.Framework;
using Yandex_practice.PageObjects;
using Yandex_practice.WrapperFactory;

namespace Yandex_practice.TestCases.YaDisk
{
    class MoveWordDoc : BaseTest
    {
        [Test]
        public void MoveDocument()
        {
            Page.Authentication.LogIn();
            Page.Passport.OpenYaDisk();
            Page.Disk.CreateSecondFolder();
            Page.Disk.CreateNewFolder();
            Page.Disk.NavigateNewFolder();
            Page.Disk.CreateNewDoc();
            WebDriverFactory.CloseWindow();
            WebDriverFactory.SwitchToRemainingWindow();            
            Page.Disk.MoveDoc();
            Page.Disk.NavigateSecondFolder();
            bool isNewDocDisplayed = Page.Disk.GetNewDoc();
            Assert.AreEqual(true, isNewDocDisplayed);            
        }
    }

}
