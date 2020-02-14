using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom_framework.Configuration;
namespace Ecom_framework.Interfaces
{
   public interface IConfig
    {
        BrowserType? GetBrowser();
        string Get_Email_address();
        string GetPassword();
        string GetWebsite();
        int GetPageLoadTimeOut();
        int GetElementLoadTimeOut();
    }
}
