using Automation.Mars.Core.Abstraction;
using Automation.Mars.Core.DriverContext;
using Automation.Mars.Core.Params;
using Automation.Mars.Core.Reports;
using Automation.Mars.Core.Selenium.LocalWebDrivers;
using Automation.Mars.Core.Selenium.WebDrivers;
using Automation.Mars.Core.WebElements;
using BoDi;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Mars.Core.DIContainer
{
    public class CoreContainerConfig
    {
        public static IServiceProvider ConfigureService()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IDefaultVariables, DefaultVariables>();
            serviceCollection.AddSingleton<ILogging, Logging>();
            serviceCollection.AddSingleton<IGlobalProperties, GlobalProperties>();
            serviceCollection.AddSingleton<IExtentFeatureReport, ExtentFeatureReport>();
            serviceCollection.AddTransient<IExtentReport, ExtentReport>();

            return serviceCollection.BuildServiceProvider();
        }

        //In CoreContainerConfig set AppContainerConfig
        public static IObjectContainer SetAppContainer(IObjectContainer iobjectContainer)
        {
            iobjectContainer.RegisterTypeAs<ChromeWebDriver, IChromeWebDriver>();
            iobjectContainer.RegisterTypeAs<FirefoxWebDriver, IFirefoxWebDriver>();
            iobjectContainer.RegisterTypeAs<Driver, IDriver>();
            iobjectContainer.RegisterTypeAs<AtBy, IAtBy>();
            iobjectContainer.RegisterTypeAs<AtWebElement, IAtWebElement>();
            return iobjectContainer;
        }
    }
}
