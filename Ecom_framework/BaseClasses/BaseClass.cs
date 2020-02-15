using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ecom_framework.Settings;
using Ecom_framework.Configuration;
using Ecom_framework.CustomException;
using Ecom_framework.ComponentHelper;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
namespace Ecom_framework.BaseClasses
{
    [TestClass]
   public class BaseClass
    {

        public static IWebDriver driver=InitWebdriver();
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


        //[AssemblyInitialize]
        //[BeforeFeature()]
        private static IWebDriver InitWebdriver()
        {
            ObjectRepository.Config = new AppConfigReader();
            // Reporter.GetReportManager();
            //Reporter.AddTestCaseMetadataToHtmlReport(tc);
            
                switch (ObjectRepository.Config.GetBrowser())
                {
                    case BrowserType.Firefox:
                        ObjectRepository.Driver = GetFirefoxDriver();
                        //Logger.Info(" Using Firefox Driver  ");

                        break;

                    case BrowserType.Chrome:
                        ObjectRepository.Driver = GetChromeDriver();
                        // Logger.Info(" Using Chrome Driver  ");
                        break;

                    //case BrowserType.IExplorer:
                    //    ObjectRepository.Driver = GetIEDriver();
                    //   // Logger.Info(" Using Internet Explorer Driver  ");
                    //    break;

                    //// Deprecated 
                    //case BrowserType.PhantomJs:
                    //    //ObjectRepository.Driver = GetPhantomJsDriver();
                    //  //  Logger.Info(" Using PhantomJs Driver  ");
                    //    break;

                    //case BrowserType.Edge:
                    //    ObjectRepository.Driver = GetEdgeDriver();
                    //    Logger.Info(" Using Edge Driver  ");
                    //    break;

                    default:
                        throw new NoSutiableDriverFound("Driver Not Found : " + ObjectRepository.Config.GetBrowser().ToString());
                }
                ObjectRepository.Driver.Manage().Cookies.DeleteAllCookies();
                ObjectRepository.Driver.Manage()
                    .Timeouts().PageLoad = TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeOut());
                ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());
                BrowserHelper.BrowserMaximize();
                
            return ObjectRepository.Driver;
        }
        [AssemblyCleanup]
        //[AfterScenario()]
        public static void TearDown()
        {
            if (ObjectRepository.Driver != null)
            {
                ObjectRepository.Driver.Close();
                ObjectRepository.Driver.Quit();
            }
           // Logger.Info(" Stopping the Driver  ");
        }
    }
}
