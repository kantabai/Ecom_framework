using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
namespace Ecom_framework.ComponentHelper
{
   public class ButtonHelper
    {
        private static IWebElement _element;

        public static void ClickButton(By locator)
        {
            _element = GenericHelper.GetElement(locator);
            _element.Click();
            
        }
    }
}
