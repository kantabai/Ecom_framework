using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
namespace Ecom_framework.ComponentHelper
{
    public class FileUplaodhelper
    {
        private static IWebElement _element;
        public static void uploadfile(By locator, string path)
        {
            _element = GenericHelper.uploadfile(locator, path);


        }
    }
}
