using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ecom_framework.PageObject;
using OpenQA.Selenium;
using Ecom_framework.TestScript;
namespace Ecom_framework
{
    [TestClass]
    public class UnitTest1
    {
        Home obj = new Home();
        ContactUs contactusobj = new ContactUs();
        Sign_In_UI sign_in_obj = new Sign_In_UI();
        Quickaddtocart Quickaddtocartobj = new Quickaddtocart();
        [TestMethod]
        public void TestMethod1()
        {
            
            obj.navigate();
           
            
        }
        [TestMethod]
        public void contactus()
        {
            obj.navigate();
            contactusobj.verify_contact_us_heading();


        }
        
        //verifying when user passes empty value
        [TestMethod]
        public void verify_error_msg()
        {
            obj.navigate();
            Contactus_test.verify_sendmsg();
        }
        //verifying when user passes all the values
        [TestMethod]
        public void sendmsg()
        {
            obj.navigate();
            Contactus_test.sendmsg();
        }
        [TestMethod]
        public void go_back_home()
        {
            obj.navigate();
            Contactus_test.goback_tohome();
        }
        [TestMethod]
        public void verify_signin_hyperlink()
        {
            obj.navigate();
            sign_in_obj.Verify_sign_hyperlink();

        }
        [TestMethod]
        public void Signin()
        {
            
            sign_in_obj.signin();
        }
        [TestMethod]
        public void quick_add_cart()
        {
            Quickaddtocartobj.quick_add_cart();
        }
        
    }
}
