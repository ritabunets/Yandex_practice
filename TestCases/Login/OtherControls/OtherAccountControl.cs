using NUnit.Framework;
using Yandex_practice.PageObjects;

namespace Yandex_practice.TestCases.Login.OtherControls
{
    class OtherAccountControl:BaseTest
    {        
        [Test]
        public void CheckOtherAccountControl()
        {
            Page.Authentication.FillInLoginValid();
            Page.Authentication.ClickLogInButton(); 
            Page.Authentication.ClickOtherAccountControl();
            string currentValue = Page.Authentication.GetLoginInputValue();
            Assert.AreEqual(string.Empty, currentValue);
        }
    }
}
