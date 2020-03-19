using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using Ecom_framework.ComponentHelper;
using Ecom_framework.Settings;
using Ecom_framework.Configuration;
using Ecom_framework.BaseClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Ecom_framework.PageObject
{
    public class Quickaddtocart
    {
        private static IWebDriver driver = BaseClass.driver;
        AppConfigReader obj = new AppConfigReader();
        IWebElement element;
        public Quickaddtocart()
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//h1[@class='page-heading bottom-indent']")]
        private IWebElement contact_us_heading { get; set; }
        [FindsBy(How=How.XPath,Using = "//a[@class='button ajax_add_to_cart_button btn btn-default']//span")]
        
        private IWebElement add_cartbtn { get; set; }
        protected internal void quick_add_cart()
        {
            string URL = obj.GetWebsite();
            NavigationHelper.NavigateToUrl(URL);
            IList<IWebElement> getcount = ObjectRepository.Driver.FindElements(By.XPath("//img[@class='replace-2x img-responsive']"));

            for(int i=0;i<getcount.Count;i++)
            {
                if(i==1)
                {
                    Actions action = new Actions(ObjectRepository.Driver);
                    action.MoveToElement(element).Perform();
                    add_cartbtn.Click();
                }
            }
        }
    }

    
}
