using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
namespace Ecom_framework.ComponentHelper
{
   public class Dropdownhelper
    {
        private static IWebElement _element;

        public static void selectvalue_fromdropdown(By locator,string value)
        {
            _element = GenericHelper.Select_valuebytext(locator, value);
            

        }
    }
}
