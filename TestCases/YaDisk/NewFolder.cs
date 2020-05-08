using NUnit.Framework;
using Yandex_practice.PageObjects;

namespace Yandex_practice.TestCases.YaDisk
{
    class NewFolder : BaseTest
    {
        [Test]
        public void AddNewFolder()
        {
            Page.Authentication.LogIn();
            Page.Passport.OpenYaDisk(); 
            Page.Disk.CreateNewFolder(); 
            bool isNewFolderDisplayed = Page.Disk.GetNewFolder();
            Assert.AreEqual(true, isNewFolderDisplayed);

        }
    }
}