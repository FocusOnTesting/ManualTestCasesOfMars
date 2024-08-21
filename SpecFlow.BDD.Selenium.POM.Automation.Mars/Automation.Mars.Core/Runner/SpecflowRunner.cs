using Automation.Mars.Core.Abstraction;
using Automation.Mars.Core.DIContainer;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using TechTalk.SpecFlow;

namespace Automation.Mars.Core.Runner
{
    [Binding]
    public class SpecflowRunner
    {
        public static IServiceProvider _iserviceProvider;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _iserviceProvider = CoreContainerConfig.ConfigureService();

            //DI container creates an instance of GlobalProperties
            _iserviceProvider.GetRequiredService<IGlobalProperties>();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext fc)
        {
            IExtentReport iextentReport = _iserviceProvider.GetRequiredService<IExtentReport>();
            //string ep = iextentReport.GetHashCode().ToString();
            //Log.Information("The hashcode of extentReport is: " + ep);
            iextentReport.CreateFeature(fc.FeatureInfo.Title);
            fc["iextentReport"] = iextentReport;
        }



        [AfterTestRun]
        public static void AfterTestRun()
        {
            Log.CloseAndFlush();
        }

    }
}
