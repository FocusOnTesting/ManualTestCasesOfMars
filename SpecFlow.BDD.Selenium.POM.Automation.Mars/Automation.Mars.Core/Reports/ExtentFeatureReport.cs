using Automation.Mars.Core.Abstraction;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Mars.Core.Reports
{
    public class ExtentFeatureReport : IExtentFeatureReport
    {
        IDefaultVariables _idefaultVariables;
        AventStack.ExtentReports.ExtentReports extentReports;
        public ExtentFeatureReport(IDefaultVariables idefaultVariables)
        {
            _idefaultVariables = idefaultVariables;
        }

        public void InitializeExtentReport()
        {
            ExtentHtmlReporter extentHtmlReporter = new ExtentHtmlReporter(_idefaultVariables.getExtentReport);
            extentReports = new AventStack.ExtentReports.ExtentReports();
            extentReports.AttachReporter(extentHtmlReporter);
        }

        public AventStack.ExtentReports.ExtentReports GetExtentReport()
        {
            return extentReports;
        }

        public void FlushExtent()
        {
            extentReports.Flush();
        }
    }
}