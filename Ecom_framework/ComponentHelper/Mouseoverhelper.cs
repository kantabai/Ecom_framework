using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Ecom_framework.Settings;
namespace Ecom_framework.ComponentHelper
{
   public class Mouseoverhelper
    {
        private static IWebElement element;
        public static void Domouseover(By Locator)
        {
            element = GenericHelper.GetElement(Locator);
            Actions action = new Actions(ObjectRepository.Driver);
            action.MoveToElement(element).Build().Perform();
            

        }

    }
}
