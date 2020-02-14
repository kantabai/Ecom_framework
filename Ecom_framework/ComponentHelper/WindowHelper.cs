using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom_framework.Settings;
namespace Ecom_framework.ComponentHelper
{
   public class WindowHelper
    {
         public static string GetTitle()
        {
            return ObjectRepository.Driver.Title;
        }
    }
}
