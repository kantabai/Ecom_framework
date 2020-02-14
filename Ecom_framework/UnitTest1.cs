using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ecom_framework.PageObject;
using OpenQA.Selenium;
namespace Ecom_framework
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
        [TestMethod]
        public void TestMethod1()
        {
            Home obj = new Home();
            obj.navigate();
        }
    }
}
