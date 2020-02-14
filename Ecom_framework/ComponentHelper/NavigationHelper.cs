using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom_framework.Settings;
namespace Ecom_framework.ComponentHelper
{
   public class NavigationHelper
    {
        public static void NavigateToUrl(string Url)
        {
            ObjectRepository.Driver.Navigate().GoToUrl(Url);
            
        }
    }
}
