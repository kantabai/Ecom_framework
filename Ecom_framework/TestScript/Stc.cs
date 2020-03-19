using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Ecom_framework.ComponentHelper;
using Ecom_framework.BaseClasses;
using SeleniumExtras.PageObjects;
using Ecom_framework.Configuration;
using System.Threading;
using Ecom_framework.Settings;
using System;

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
                AssertHelper.AreEqual("Moviessasa", element.Text);
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


    }
}
