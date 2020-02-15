using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Ecom_framework.ComponentHelper;
using Ecom_framework.Settings;
using Ecom_framework.Configuration;
using Ecom_framework.BaseClasses;
namespace Ecom_framework.PageObject
{
    public class Home
    {

        private static IWebDriver driver = BaseClass.driver;
        
        AppConfigReader obj = new AppConfigReader();
        [FindsBy(How=How.XPath,Using = "//a[text()='Contact us']")]
        private IWebElement contact_us { get; set; }


        public Home()
        {
           
            PageFactory.InitElements(driver, this);
            

        }
        
        protected internal void navigate()
        {
            string URL = obj.GetWebsite();
            NavigationHelper.NavigateToUrl(URL);
            contact_us.Click();
           // return new ContactUs();
        }
        public string Title
        {
            get { return driver.Title; }
        }
    }
}
