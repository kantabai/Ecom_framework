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
namespace Ecom_framework.PageObject
{
   public class ContactUs
    {
        private static IWebDriver driver =BaseClass.driver;
        public ContactUs()
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How=How.XPath,Using = "//h1[@class='page-heading bottom-indent']")]
        private IWebElement contact_us_heading { get; set;}

        [FindsBy(How=How.Id,Using = "id_contact")]
        private IWebElement Subject_Heading { get; set;}
        [FindsBy(How=How.Id,Using = "email")]
        private IWebElement emailtextbox { get; set;}
        [FindsBy(How=How.Id,Using = "id_order")]
        private IWebElement order_ref { get; set; }

        [FindsBy(How=How.Id,Using = "fileUpload")]
        private IWebElement Attach_File { get; set; }
        [FindsBy(How = How.Id, Using = "//button[@type='submit']")]
        private IWebElement send_button { get; set; }

        
        protected internal void verify_contact_us_heading()
        {
            string value = contact_us_heading.Text;

            AssertHelper.AreEqual("Customer service - Contact us", value);
        }

       
       

    }

   
    //you can pull the page element and value from db,excel,csv,app config file
}
