using System.Threading;
using OpenQA.Selenium;
using Ecom_framework.Settings;
namespace Ecom_framework.ComponentHelper
{
   public class JavaScriptExecutor
    {
        public static object ExecuteScript(string script)
        {
            IJavaScriptExecutor executor = ((IJavaScriptExecutor)ObjectRepository.Driver);
            
            return executor.ExecuteScript(script);

        }

        public static object ExecuteScript(string script, params object[] args)
        {
            IJavaScriptExecutor executor = ((IJavaScriptExecutor)ObjectRepository.Driver);
            return executor.ExecuteScript(script, args);
        }

        public static void ScrollToAndClick(IWebElement element)
        {
            ExecuteScript("window.scrollTo(0," + element.Location.Y + ")");
            Thread.Sleep(300);
            element.Click();
        }

        public static void ScrollToAndClick(By locator)
        {
            IWebElement element = GenericHelper.GetElement(locator);
            ExecuteScript("window.scrollTo(0," + element.Location.Y + ")");
            Thread.Sleep(300);
            element.Click();
        }

        public static void ScrollIntoViewAndClick(By locator)
        {
            IWebElement element = GenericHelper.GetElement(locator);
            ExecuteScript("arguments[0].scrollIntoView()", element);
            ExecuteScript("arguments[0].click();", element);
            Thread.Sleep(300);
        }
       
    }
}
