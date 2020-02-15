using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom_framework.PageObject;
using Ecom_framework.ComponentHelper;
using OpenQA.Selenium;
using Ecom_framework.Settings;
namespace Ecom_framework.TestScript
{
    public class Contactus_test
    {
        private static IWebElement element;
        //verifying when user passes empty value
        protected internal static void verify_sendmsg()
        {
            ButtonHelper.ClickButton(By.Id("submitMessage"));
            IWebElement element = ObjectRepository.Driver.FindElement(By.XPath("//div[@class='alert alert-danger']//ol//li"));
            string actualvalue = element.Text;
            string value = "Invalid email address";
            AssertHelper.AreEqual(value, actualvalue);
        }
        //verifying when user fills all the data
        //you can chnage the value by reading the value from excel,csv,config
        protected internal static void sendmsg()
        {

            GenericHelper.WaitForWebElementInPage(By.Id("id_contact"), TimeSpan.FromSeconds(30));
            if (GenericHelper.IsElemetPresent(By.Id("id_contact")))
            {
                Dropdownhelper.selectvalue_fromdropdown(By.Id("id_contact"), "Customer service");

                TextBoxHelper.TypeInTextBox(By.Id("email"), "nirmal@gmail.com");
                TextBoxHelper.TypeInTextBox(By.Id("id_order"), "O0001F");
                FileUplaodhelper.uploadfile(By.Id("fileUpload"), @"C:\Users\Nirmal\Desktop\coupon.PNG");
                TextBoxHelper.TypeInTextBox(By.Id("message"), "test");
                ButtonHelper.ClickButton(By.Id("submitMessage"));

                element = ObjectRepository.Driver.FindElement(By.XPath("//p[@class='alert alert-success']"));
                string expected = "Your message has been successfully sent to our team";
                AssertHelper.AreEqual(expected, element.Text);
            }
            else
            {
                throw new NoSuchElementException();
            }
           
        }
        protected internal static void goback_tohome()
        {
            sendmsg();
           element=ObjectRepository.Driver.FindElement(By.XPath("//i[@class='icon-chevron-left']"));
            element.Click();

        }

    }
}
