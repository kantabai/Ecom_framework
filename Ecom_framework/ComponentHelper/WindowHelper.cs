using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom_framework.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
namespace Ecom_framework.ComponentHelper
{
   public class WindowHelper
    {
        private static IWebElement element;
        public static string GetTitle()
        {
            return ObjectRepository.Driver.Title;
        }

        
       

    }
}
