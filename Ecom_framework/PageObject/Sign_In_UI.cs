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
    public class Sign_In_UI
    {
        private static IWebDriver driver = BaseClass.driver;
        
        public Sign_In_UI()
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign in')]")]
        private IWebElement sign_in { get; set; }

        [FindsBy(How = How.XPath, Using = "//h3[@class='page-subheading']")]
        private IWebElement sign_in_heading { get; set; }
        


        protected internal void Verify_sign_hyperlink()
        {
            LinkHelper.ClickLink(By.XPath("//a[@class='login']"));
            string headingtext = sign_in_heading.Text;
            AssertHelper.AreEqual("ALREADY REGISTERED?", headingtext);


        }
    }
}
