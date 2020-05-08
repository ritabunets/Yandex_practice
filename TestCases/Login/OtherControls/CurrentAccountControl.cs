using NUnit.Framework;
using Yandex_practice.PageObjects;

namespace Yandex_practice.TestCases.Login.OtherControls
{
    class CurrentAccountControl:BaseTest
    {
        [Test]
        public void CheckCurrentAccountControl()
        {

            Page.Authentication.FillInLoginValid();
            Page.Authentication.ClickLogInButton();
            Page.Authentication.ClickCurrentAccountControl();
            string currentValue = Page.Authentication.GetLoginInputValue();
            Assert.AreEqual(string.Empty, currentValue);
        }
    }
}
