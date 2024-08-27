using Automation.Mars.Core.Abstraction;
using Automation.Mars.Core.Runner;
using BoDi;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.Mars.POM.Hooks
{
    [Binding]
    public class SpecflowBase
    {
        IDriver _idriver;

        [BeforeScenario(Order = 2)]
        public void BeforeScenario(IObjectContainer iobjectContainer, ScenarioContext sc, FeatureContext fc)
        {
            // get a driver from DI container BoDi which is a very simple IoC container for Specflow.
            _idriver = iobjectContainer.Resolve<IDriver>();
            IExtentReport extentReport = (IExtentReport)fc["iextentReport"];
            extentReport.CreateScenario(sc.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterSteps(ScenarioContext sc, FeatureContext fc)
        {
            IExtentReport extentReport = (IExtentReport)fc["iextentReport"];
            if (sc.TestError != null)
            {
                Log.Information("Test Error: " + sc.TestError);
                string base64 = null;
                base64 = _idriver.GetScreenShot();
                extentReport.Fail(sc.StepContext.StepInfo.Text, base64);
            }
            else
            {
                IGlobalProperties iglobalProperties = SpecflowRunner._iserviceProvider.GetRequiredService<IGlobalProperties>();
                string base64 = null;
                if (iglobalProperties.stepScreenShot)
                {
                    base64 = _idriver.GetScreenShot();
                }
                extentReport.Pass(sc.StepContext.StepInfo.Text, base64);
            }
        }


        [AfterScenario]
        public void AfterScenario()
        {
            // flush HTML reports to loacl device
            IExtentFeatureReport extentFeatureReport = SpecflowRunner._iserviceProvider.GetRequiredService<IExtentFeatureReport>();
            extentFeatureReport.FlushExtent();
            // quit browser after a scenario
            _idriver.CloseBrowser();
        }
    }
}
