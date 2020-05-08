using Yandex_practice.WrapperFactory;
using Selenium.Community.PageObjects;


namespace Yandex_practice.PageObjects
{
    public static class Page
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            new PageObjectFactory(WebDriverFactory.Driver).InitElements(page);           
            return page;
        }

         public static AuthenticationPage Authentication => GetPage<AuthenticationPage>();

         public static PassportPage Passport => GetPage<PassportPage>();

         public static DiskPage Disk => GetPage<DiskPage>();

    }
}
