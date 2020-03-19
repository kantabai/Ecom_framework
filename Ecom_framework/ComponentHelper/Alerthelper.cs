using Ecom_framework.Settings;
using OpenQA.Selenium;

namespace Ecom_framework.ComponentHelper
{
    public static class Alerthelper
    {
        public static void SwitchtoAlert()
        {

            IAlert alert = ObjectRepository.Driver.SwitchTo().Alert();
            alert.Accept();
        }
        public static void CancelAlert()
        {
            IAlert alert = ObjectRepository.Driver.SwitchTo().Alert();
            alert.Dismiss();
        }

    }
}
