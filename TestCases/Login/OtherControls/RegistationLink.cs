using NUnit.Framework;
using Yandex_practice.PageObjects;
using Yandex_practice.WrapperFactory;
using Yandex_practice.TestConfig;

namespace Yandex_practice.TestCases.Login.OtherControls
{
    class RegistarionLink : BaseTest
    {
        [Test]
        public void CheckRegistationLink()
        {
            Page.Authentication.FollowRegistationLink();
            string currentTitle = WebDriverFactory.GetTitle();
            Assert.AreEqual(Constants.registrationpagetitle, currentTitle);
        }                     
                     
    }
}