using Automation.Mars.Core.Abstraction;
using Automation.Mars.Core.Runner;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Mars.Core.Selenium.LocalWebDrivers
{
    public class EdgeWebDriver : IEdgeWebDriver
    {
        IWebDriver iwebdriver;
        IGlobalProperties _iglobalProperties;
        public EdgeWebDriver()
        {
            _iglobalProperties = SpecflowRunner._iserviceProvider.GetRequiredService<IGlobalProperties>();
        }

        public IWebDriver GetEdgeWebDriver()
        {
            iwebdriver = new EdgeDriver(GetOptions());
            //iwebdriver.Manage().Window.Maximize();
            return iwebdriver;
        }
        public EdgeOptions GetOptions()
        {
            EdgeOptions options = new EdgeOptions();
            options.AcceptInsecureCertificates = true;
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-infobars");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--ignore-certificate-errors");
            //options.AddArgument("--inprivate");
            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalOption("useAutomationExtension", false);
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("download.default_directory", _iglobalProperties.dataSetLocation);

            return options;
        }
    }
}
