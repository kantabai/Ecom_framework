using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Ecom_framework.Interfaces;
namespace Ecom_framework.Settings
{
   public class ObjectRepository
    {
        public static IConfig Config { get; set; }
        public static IWebDriver Driver { get; set; }
    }
}
