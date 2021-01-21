using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Yandex_practice.Tests.TestConfig
{
    
    public static class Constants
    {
        public static IConfiguration TestConfiguration = new ConfigurationBuilder().AddJsonFile("Tests\\TestConfig.json").Build();
        public static string login => TestConfiguration["ValidUser:login"];
        public static string password => TestConfiguration["ValidUser:password"];
        public static string url => TestConfiguration["Driver:url"];
        public static string browserName => TestConfiguration["Driver:browserName"];
        public static string gmail => TestConfiguration["ValidUser:gmail"];
        public static string invalidlogin => TestConfiguration["InvalidUser:invalidlogin"];
        public static string invalidpassword => TestConfiguration["InvalidUser:invalidpassword"];
        public static string screenshotdirectory => TestConfiguration["Driver:screenshotdirectory"];
    }
}