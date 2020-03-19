using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelevantCodes.ExtentReports;
using System.Configuration;
namespace Ecom_framework.ComponentHelper
{
  public class GenerateReporthelper
    {
        public static ExtentReports report;
        public static ExtentTest logger;
        //public static string path = ConfigurationManager.AppSettings["rpath"].ToString();
        public static string path = @"C:\Users\Nirmal\Desktop\report";

        public static void extentreportpass(string testmethod_name, string test_status)
        {


            
            report = new ExtentReports(path, false);
            logger = report.StartTest(testmethod_name);
            logger.Log(LogStatus.Info, test_status);
           logger.Log(LogStatus.Pass, "pass");
            report.EndTest(logger);
            report.Flush();
            
        }

        public static void extentreportfail(string testmethod_name, string test_status, string test_status1, string result)
        {



            report = new ExtentReports(path, false);
            logger = report.StartTest(testmethod_name);
            logger.Log(LogStatus.Info, test_status);
            logger.Log(LogStatus.Info, test_status1);
            logger.Log(LogStatus.Fail, result);
            report.EndTest(logger);
            report.Flush();

        }

    }
}
