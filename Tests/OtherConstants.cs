using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Yandex_practice.Tests.TestData
{
    public static class OtherConstants
    {
        public static IConfiguration TestConfiguration = new ConfigurationBuilder().AddJsonFile("Tests\\TestData.json").Build();
        public static string personalinfo => TestConfiguration["UserData:personalinfo"];        
        public static string emptyloginerror => TestConfiguration["Errors:emptyloginerror"];
        public static string emptypassworderror => TestConfiguration["Errors:emptypassworderror"];
        public static string invalidloginerror => TestConfiguration["Errors:invalidloginerror"];
        public static string invalidpassworderror => TestConfiguration["Errors:invalidpassworderror"];
        public static string yadiskpagetitle => TestConfiguration["Titles:yadiskpagetitle"];
        public static string updatedcontent => TestConfiguration["Common:updatedcontent"];
        public static string secondfolder => TestConfiguration["Common:secondfolder"]; 

    }
}
