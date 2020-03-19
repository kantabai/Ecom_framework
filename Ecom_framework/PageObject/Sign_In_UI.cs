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
        AppConfigReader obj = new AppConfigReader();
        private static IWebDriver driver ;
        
        public Sign_In_UI()
        {
            driver=BaseClass.driver;
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign in')]")]
        private IWebElement sign_in { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement Email_addresstxtbox { get; set; }


        [FindsBy(How = How.Id, Using = "passwd")]
        private IWebElement passwordtxtbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//h3[@class='page-subheading']")]
        private IWebElement sign_in_heading { get; set; }
        
        [FindsBy(How=How.XPath,Using = "//span/i[@class='icon-lock left']")]
        private IWebElement signinbtn { get; set; }

        [FindsBy(How=How.XPath,Using = "//ol//li")]
        private IWebElement geterrormsg { get; set; }
        protected internal void Verify_sign_hyperlink()
        {
            LinkHelper.ClickLink(By.XPath("//a[@class='login']"));
            string headingtext = sign_in_heading.Text;
            AssertHelper.AreEqual("ALREADY REGISTERED?", headingtext);


        }

        protected internal void signin()
        {
            string URL = obj.GetWebsite();
            NavigationHelper.NavigateToUrl(URL);
            sign_in.Click();
            string emailid = obj.Get_Email_address();
            string password = obj.GetPassword();
            Email_addresstxtbox.SendKeys(emailid);
            passwordtxtbox.SendKeys(password);
            signinbtn.Click();

            string msg = geterrormsg.Text;
            AssertHelper.AreEqual("Authentication failed.", msg);
            GenerateReporthelper.extentreportpass("signin", "pass");
        }
    }
}
