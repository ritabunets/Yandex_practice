using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Yandex_practice.TestConfig
{
    
    public static class Constants
    {
        
        public static IConfiguration TestConfiguration = new ConfigurationBuilder().AddJsonFile("TestConfig.json").Build();
        public static string login => TestConfiguration["Settings:Common:login"];
        public static string password => TestConfiguration["Settings:Common:password"];
        public static string firstname => TestConfiguration["Settings:Common:firstname"];
        public static string lastname => TestConfiguration["Settings:Common:lastname"];
        public static string url => TestConfiguration["Settings:Common:url"];
        public static string gmail => TestConfiguration["Settings:Common:gmail"];
        public static string emptyloginerror => TestConfiguration["Settings:Common:emptyloginerror"];
        public static string emptypassworderror => TestConfiguration["Settings:Common:emptypassworderror"];
        public static string invalidlogin => TestConfiguration["Settings:Common:invalidlogin"];
        public static string invalidloginerror => TestConfiguration["Settings:Common:invalidloginerror"];
        public static string invalidpassword => TestConfiguration["Settings:Common:invalidpassword"];
        public static string invalidpassworderror => TestConfiguration["Settings:Common:invalidpassworderror"];
        public static string registrationpagetitle => TestConfiguration["Settings:Common:registrationpagetitle"];
        public static string yadiskpagetitle => TestConfiguration["Settings:Common:yadiskpagetitle"];
        public static string updatedcontent => TestConfiguration["Settings:Common:updatedcontent"];
        public static string secondfolder => TestConfiguration["Settings:Common:secondfolder"];
        public static string screenshotdirectory => TestConfiguration["Settings:Common:screenshotdirectory"];

    }

}