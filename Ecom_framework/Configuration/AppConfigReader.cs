using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom_framework.Interfaces;
using System.Configuration;
namespace Ecom_framework.Configuration
{
    public class AppConfigReader: IConfig
    {
        public BrowserType? GetBrowser()
        {
          
            string browser = ConfigurationManager.AppSettings["Browser"];
            try
            {
                return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public int GetElementLoadTimeOut()
        {
            string timeout = ConfigurationManager.AppSettings["ElementLoadTimeout"];
            if (timeout == null)
                return 30;
            return Convert.ToInt32(timeout);
        }
        public int GetPageLoadTimeOut()
        {
            string timeout = ConfigurationManager.AppSettings["PageLoadTimeout"];
            if (timeout == null)
                return 30;
            return Convert.ToInt32(timeout);
        }

        public string GetPassword()
        {
            return ConfigurationManager.AppSettings["Password"];
        }
        public string Get_Email_address()
        {
            return ConfigurationManager.AppSettings["Email_address"];
        }
        public string GetWebsite()
        {
            return ConfigurationManager.AppSettings["URL"];
        }
    }
}
