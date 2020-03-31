using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Ecom_framework.ComponentHelper;
using Ecom_framework.BaseClasses;
using SeleniumExtras.PageObjects;
using Ecom_framework.Configuration;
using System.Threading;
using Ecom_framework.Settings;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;

namespace Ecom_framework.TestScript
{
    [TestClass]
    public class Stc
    {
        AppConfigReader obj = new AppConfigReader();
        private static IWebDriver driver;
        private static IWebElement element;
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Stc()
        {
            driver = BaseClass.driver;
            PageFactory.InitElements(driver, this);
            string URL = obj.GetWebsite();
            NavigationHelper.NavigateToUrl(URL);
            BrowserHelper.BrowserMaximize();
        }
        
        
        [TestMethod]
        public void checklinks()
        {
            
            //Event link click
            LinkHelper.ClickLink(By.XPath("//a[@href='Event']"));
            //Sports link click
            LinkHelper.ClickLink(By.Id("hsports"));
            //Leisure link click
            LinkHelper.ClickLink(By.Id("hleisure"));
            //Business link click
            LinkHelper.ClickLink(By.Id("hbusiness"));
        }
        [TestMethod]
        public void checkmovieslink()
        {
            try
            {
                //Movies link click
                LinkHelper.ClickLink(By.XPath("//a[@href='Movies']"));
                Thread.Sleep(2000);
                element = ObjectRepository.Driver.FindElement(By.XPath("//div[@class='row m-0']//h2"));
                AssertHelper.AreEqual("Movies", element.Text);
            }
            catch(Exception e)
            {
                
                log.Info(e.StackTrace);
            }

          


        }
        [TestMethod]
        public void checkeventslink()
        {
            LinkHelper.ClickLink(By.XPath("//a[@href='Event']"));
            Thread.Sleep(2000);
            element = ObjectRepository.Driver.FindElement(By.XPath("//h2[text()='Event']"));
            AssertHelper.AreEqual("Event", element.Text);
        }

        [TestMethod]
        public void checksportslink()
        {
            LinkHelper.ClickLink(By.XPath("//a[@href='hsports']"));
            Thread.Sleep(2000);
            element = ObjectRepository.Driver.FindElement(By.XPath("//h2[text()='Sports']"));
            AssertHelper.AreEqual("Sports", element.Text);
        }
        [TestMethod]
        public void checkleisurelink()
        {
            LinkHelper.ClickLink(By.Id("hleisure"));
            Thread.Sleep(2000);
            element = ObjectRepository.Driver.FindElement(By.XPath("//h2[@class='boldFont activeHeading arTextRight']/span"));
            AssertHelper.AreEqual("Leisure", element.Text);
        }
        [TestMethod]
        public void checkBusinesslink()
        {
            LinkHelper.ClickLink(By.Id("hbusiness"));
            Thread.Sleep(2000);
            element = ObjectRepository.Driver.FindElement(By.XPath("//h2[@class='boldFont activeHeading arTextRight']/span"));
            AssertHelper.AreEqual("Leisure", element.Text);
        }

        [TestMethod]
        public void do_search()
        {
            LinkHelper.ClickLink(By.XPath("//img[@alt='Search Icon']"));
            Thread.Sleep(2000);
            TextBoxHelper.TypeInTextBox(By.Id("searchInput"), "for");
            
            IList<IWebElement> getcount = ObjectRepository.Driver.FindElements(By.XPath("//div[@class='bg-light mt-1 rounded text-left']//ul//li"));
            
            for(int i=1;i<=getcount.Count;i++)
            {

                element = ObjectRepository.Driver.FindElement(By.XPath("//div[@class='bg-light mt-1 rounded text-left']//ul//li"));
                if(element.Text== "Formula 1 Gulf Air Bahrain 2020")
                {
                    element.Click();
                }
            }
        }
        [TestMethod]
        public void close_searchbox()
        {
            LinkHelper.ClickLink(By.XPath("//img[@alt='Search Icon']"));
            Thread.Sleep(2000);
            LinkHelper.ClickLink(By.XPath("//li[@id='searchSection']//a//img"));
           
        }
        [TestMethod]
        public void sign_in()
        {
            LinkHelper.ClickLink(By.XPath("//a[@href='SignIn']"));
            TextBoxHelper.TypeInTextBox(By.Id("signInEmail"), "nirmal3131@360-bytes.com");
            TextBoxHelper.TypeInTextBox(By.Id("signInPassword"), "TESTtest@123");
            ButtonHelper.ClickButton(By.Id("btnSignIn"));
            element = ObjectRepository.Driver.FindElement(By.Id("hdefault"));
            bool value = element.Displayed;
            if(value==true)
            {
                AssertHelper.AreEqual("Home ", element.Text);
               
                
            }
        }
        [TestMethod]
        public void sign_out()
        {
            sign_in();
            LinkHelper.ClickLink(By.Id("LogOut"));
        }

        [TestMethod]
        public void ForgotPassword()
        {
            LinkHelper.ClickLink(By.XPath("//a[@href='SignIn']"));
            LinkHelper.ClickLink(By.XPath("//u[@class='d-flex justify-content-center text-black f-14']"));
            TextBoxHelper.TypeInTextBox(By.Id("resetInput"), "nirmal3131@360-bytes.com");
            ButtonHelper.ClickButton(By.Id("resetSubmit"));
            element = ObjectRepository.Driver.FindElement(By.XPath("//h2[@class='boldFont lineHeight']"));
            AssertHelper.AreEqual("Reset password", element.Text);


        }

        //hprofile

        [TestMethod]
        public void Editprofile()
        {
            //need to check with autoit
            sign_in();
            LinkHelper.ClickLink(By.Id("hprofile"));
            LinkHelper.ClickLink(By.XPath("//a[@href='editProfile']"));
           // LinkHelper.ClickLink(By.Id("imgshow"));
          //JavaScriptExecutor.uploadfile(By.Id("imgshow"), @"C:\Users\Nirmal\source\repos\Ecom_framework\ProfilePic.png");



        }
        [TestMethod]
        public void changepassword()
        {
            sign_in();
            LinkHelper.ClickLink(By.Id("hprofile"));
            LinkHelper.ClickLink(By.XPath("//a[@href='changePassword']"));
            //textbox  current password textbox
            //pass the current password
            TextBoxHelper.TypeInTextBox(By.Id("currentpwd"),"");
            //textbox  new password textbox
            //pass the new password
            TextBoxHelper.TypeInTextBox(By.Id("newpwd"), "");

            //textbox  re_enter password textbox
            //pass the re_enter password
            TextBoxHelper.TypeInTextBox(By.Id("re_newpwd"), "");
            ButtonHelper.ClickButton(By.Id("changePassword"));

        }
        //This method is used to validate sign-in form error message
        [TestMethod]
        public void validate_error_msg()
        {
            LinkHelper.ClickLink(By.XPath("//a[@href='SignIn']"));
            TextBoxHelper.TypeInTextBox(By.Id("signInEmail"), "");
            element = ObjectRepository.Driver.FindElement(By.ClassName("errormsg"));
            string text = element.Text;
            log.Info(text);
            TextBoxHelper.TypeInTextBox(By.Id("signInEmail"), "nirmal3131@");
            element=  ObjectRepository.Driver.FindElement(By.Id("signInPassword"));
            element.Click();
            element = ObjectRepository.Driver.FindElement(By.ClassName("errormsg"));
            text= element.Text;
            log.Info(text);
        }
        [TestMethod]
        public void bookevent()
        {
            IList<IWebElement> getval = ObjectRepository.Driver.FindElements(By.XPath("//div[@class='owl-item active']//div[@class='item ng-scope']//div//a[text()='Book ticket']"));
            for(int i=1;i< getval.Count;i++)
            {
                if(i!=1)
                {
                    LinkHelper.ClickLink(By.LinkText("Book ticket"));

                    break;
                }
            }
          
        
        }
        [TestMethod]
        public void eventreadmore()
        {
           IWebElement getval = ObjectRepository.Driver.FindElement(By.XPath("//p[@class='mt-0 mt-lg-3']"));
            IList<IWebElement> getcount = getval.FindElements(By.TagName("a"));
            for(int i=1;i<=getcount.Count;i++)
            {
                
                element = ObjectRepository.Driver.FindElement(By.XPath("//*[@id='banner']/div[1]/div/div[4]/div/div[2]/div/p[5]/span[2]/a"));
                ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                element.Click();
                
            }

        }

        [TestMethod]
        public void moviereadmore()
        {
            LinkHelper.ClickLink(By.XPath("//a[@href='Movies']"));
            IWebElement getval = ObjectRepository.Driver.FindElement(By.XPath("//p[@class='mt-0 mt-lg-3']"));
            IList<IWebElement> getcount = getval.FindElements(By.TagName("a"));
            if(getcount.Count==2)
            {
                ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                element = ObjectRepository.Driver.FindElement(By.XPath("//*[@id='bannerListing']/div[1]/div/div[4]/div/div[2]/div/p[5]/a"));
                ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                
                element.Click();
            }
        }
    }
}
