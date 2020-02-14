using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom_framework.Settings;
using OpenQA.Selenium;
namespace Ecom_framework.ComponentHelper
{
   public class TextBoxHelper
    {
        private static IWebElement element;
        public static void TypeInTextBox(By locator, string text)
        {
            element = GenericHelper.GetElement(locator);
            element.SendKeys(text);
           
        }

        public static void ClearTextBox(By locator)
        {
            element = GenericHelper.GetElement(locator);
            element.Clear();
            
        }
    }
}
