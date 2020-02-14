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
        
        private IWebDriver driver= BaseClass.InitWebdriver();
        [FindsBy(How=How.XPath,Using = "//a[text()='Contact us']")]
        private IWebElement contact_us { get; set; }


        //public Home(IWebDriver _driver)
        //{
        //    PageFactory.InitElements(_driver, this);
        //    this.driver = _driver;

        //}
        public Home()
        {
            PageFactory.InitElements(driver, this);
            

        }
        public void navigate()
        {

            NavigationHelper.NavigateToUrl("http://automationpractice.com/index.php");
        }
    }
}
