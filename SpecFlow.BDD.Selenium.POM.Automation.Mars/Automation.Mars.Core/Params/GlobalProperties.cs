using Automation.Mars.Core.Abstraction;
using Automation.Mars.Core.Reports;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Mars.Core.Params
{
    public class GlobalProperties : IGlobalProperties
    {
        IDefaultVariables _idefaultVariables;
        ILogging _ilogging;
        IExtentFeatureReport _iextentFeatureReport;

        //declare properties mapping frameworkSettings.json file
        public string browserType { get; set; }
        public string gridHubUrl { get; set; }
        public bool stepScreenShot { get; set; }
        public string extentReportPortalUrl { get; set; }
        public bool extentReportToPortal { get; set; }
        public string logLevel { get; set; }
        public string dataSetLocation { get; set; }
        public string downloadedLocation { get; set; }

        //inject DefaultVariables and Logging object ot GlobalProperties
        public GlobalProperties(IDefaultVariables idefaultVariables, ILogging ilogging, IExtentFeatureReport extentFeatureReport)
        {
            _idefaultVariables = idefaultVariables;
            _ilogging = ilogging;
            _iextentFeatureReport = extentFeatureReport;
            //Call Configuration to read frameworkSettings.json file and format log.txt
            Configuration();

        }

        public void Configuration()
        {
            var builder = (dynamic)null;
            try
            {
                //use ConfigurationBuilder to AddJsonFile then Build
                //This is Builder Pattern
                builder = new ConfigurationBuilder().AddJsonFile(_idefaultVariables.getframeworkSettingjson).Build();
                Console.WriteLine(builder["BrowserType"]);
            }
            catch (Exception e)
            {
                _ilogging.Error("File does not exists. " + e.Message);
                System.Environment.Exit(0);
            }

            //initialize properties after reading frameworkSettings.json file
            browserType = string.IsNullOrEmpty(builder["BrowserType"]) ? "chrome" : builder["BrowserType"];
            gridHubUrl = string.IsNullOrEmpty(builder["GridHubUrl"]) ? "" : builder["GridHubUrl"];
            stepScreenShot = builder["StepScreenShot"].ToLower().Equals("on") ? true : false;
            extentReportPortalUrl = builder["ExtentReportPortalUrl"];
            extentReportToPortal = builder["ExtentReportToPortal"].ToLower().Equals("on") ? true : false;
            logLevel = builder["LogLevel"];
            dataSetLocation = string.IsNullOrEmpty(builder["DataSetLocation"]) ? _idefaultVariables.dataSetLocation : builder["DataSetLocation"];
            downloadedLocation = string.IsNullOrEmpty(builder["DataSetLocation"]) ? _idefaultVariables.dataSetLocation : builder["DownloadedLocation"];
            _iextentFeatureReport.InitializeExtentReport();
            //call Logging class function to set log level
            _ilogging.LogLevel(logLevel);

            //call Logging class function to format log.txt file
            _ilogging.Debug("********************************************************************************");
            _ilogging.Information("********************************************************************************");
            _ilogging.Information("Configuration |RUN PARAMETERS");
            _ilogging.Information("********************************************************************************");
            _ilogging.Information("Configuration|BROWSER TYPE: " + browserType);
            _ilogging.Information("Configuration|GRID HUB URL: " + gridHubUrl);
            _ilogging.Information("Configuration|STEP SCREENSHOT: " + stepScreenShot);
            _ilogging.Information("Configuration|EXTENT REPORT PORTAL URL: " + extentReportPortalUrl);
            _ilogging.Information("Configuration|EXTENT REPORT LOCALLY: " + extentReportToPortal);
            _ilogging.Information("Configuration|LOG LEVEL: " + logLevel);
            _ilogging.Information("Configuration|DATA SET LOCATION: " + dataSetLocation);
            _ilogging.Information("Configuration|DOWNLOADED LOCATION: " + dataSetLocation);
            _ilogging.Information("********************************************************************************");
            _ilogging.Information("********************************************************************************");
        }
    }
}
