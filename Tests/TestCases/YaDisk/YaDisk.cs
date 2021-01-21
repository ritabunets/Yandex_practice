using NUnit.Framework;
using Yandex_practice.PageObjects;
using Yandex_practice.Tests.TestData;
using Yandex_practice.Tests.TestConfig;
using Yandex_practice.WrapperFactory;

namespace Yandex_practice.Tests.TestCases.YaDisk
{
    [TestFixture]

    [Parallelizable(ParallelScope.All)]
    class YaDisk: BaseTest
    {
        private readonly string docname = "test";

        private readonly string newdocname = "renamed";

        private readonly string updatedcontent = "updated";

        [Test]
        public void AddDocument()
        {
            Page.Authentication.LogIn();
            Page.Passport.OpenYaDisk();
            Page.Disk.CreateNewFolder();
            Page.Disk.NavigateNewFolder();
            Page.Disk.CreateNewDoc(docname);
            WebDriverFactory.SwitchToOriginalWindow();
            bool isNewDocExist = Page.Disk.IsDocExist(docname);
            Assert.IsTrue(isNewDocExist);
        }

        [Test]
        public void MoveDocument()
        {
            Page.Authentication.LogIn();
            Page.Passport.OpenYaDisk();
            Page.Disk.CreateSecondFolder();
            Page.Disk.CreateNewFolder();
            Page.Disk.NavigateNewFolder();
            Page.Disk.CreateNewDoc(docname);
            WebDriverFactory.CloseWindow();
            WebDriverFactory.SwitchToFirstWindow();
            Page.Disk.MoveDoc();
            Page.Disk.NavigateSecondFolder();
            bool isNewDocExist = Page.Disk.IsDocExist(docname);
            Assert.IsTrue(isNewDocExist);
        }

        [Test]
        public void AddNewFolder()
        {
            Page.Authentication.LogIn();
            Page.Passport.OpenYaDisk();
            Page.Disk.CreateNewFolder();
            bool isFolderCreated = Page.Disk.CheckNewFolder();
            Assert.IsTrue(isFolderCreated);
        }

        [Test]
        public void RemoveDocument()
        {
            Page.Authentication.LogIn();
            Page.Passport.OpenYaDisk();
            Page.Disk.CreateNewDoc(docname);
            WebDriverFactory.CloseWindow();
            WebDriverFactory.SwitchToFirstWindow();
            Page.Disk.RemoveDoc(docname);
            WebDriverFactory.ReloadThePage();
            bool isNewDocExist = Page.Disk.IsDocExist(docname);
            Assert.IsFalse(isNewDocExist);
        }                

        [Test]
        public void RenameDocument()
        {
            Page.Authentication.LogIn();
            Page.Passport.OpenYaDisk();
            Page.Disk.CreateNewDoc(docname);
            WebDriverFactory.CloseWindow();
            WebDriverFactory.SwitchToFirstWindow();
            Page.Disk.RenameDoc(newdocname);
            WebDriverFactory.CloseWindow();
            WebDriverFactory.SwitchToFirstWindow();
            WebDriverFactory.ReloadThePage();
            bool isNewDocExist = Page.Disk.IsDocExist(newdocname);
            Assert.IsTrue(isNewDocExist);
        }

        [Test]
        public void UpdateDocument()
        {
            Page.Authentication.LogIn();
            Page.Passport.OpenYaDisk();
            Page.Disk.CreateNewDoc(docname);
            WebDriverFactory.CloseWindow();
            WebDriverFactory.SwitchToFirstWindow();
            Page.Disk.UpdateDoc(updatedcontent);
            WebDriverFactory.CloseWindow();
            WebDriverFactory.SwitchToFirstWindow();
            string updatedDocContent = Page.Disk.GetUpdatedDoc();
            Assert.AreEqual(OtherConstants.updatedcontent, updatedDocContent);
        }
    }
}
