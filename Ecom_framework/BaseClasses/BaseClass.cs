using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Ecom_framework.BaseClasses
{
    [TestClass]
   public class BaseClass
    {
        private static FirefoxProfile GetFirefoxProfile()
        {
            FirefoxProfile profile = new FirefoxProfile();
            FirefoxProfileManager manager = new FirefoxProfileManager();
            return profile;
        }
        private static FirefoxOptions GetFirefoxOptions()
        {
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.Profile = GetFirefoxProfile();
            firefoxOptions.AcceptInsecureCertificates = true;
            return firefoxOptions;
        }
        private static FirefoxOptions GetOptions()
        {
            FirefoxProfileManager manager = new FirefoxProfileManager();

            FirefoxOptions options = new FirefoxOptions()
            {
                Profile = manager.GetProfile("default"),
                AcceptInsecureCertificates = true,

            };
            return options;
        }
        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("start-maximized");
            return option;
        }
        private static FirefoxDriver GetFirefoxDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            FirefoxDriver driver = new FirefoxDriver(GetFirefoxOptions());
            return driver;
        }
        private static ChromeDriver GetChromeDriver()
        {
            ChromeDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }
    }
}
