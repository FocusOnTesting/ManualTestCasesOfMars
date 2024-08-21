using Automation.Mars.POM.Configuration;
using Automation.Mars.POM.Pages;
using Automation.Mars.POM.WebAbstraction;
using Automation.Mars.Core.Abstraction;
using Automation.Mars.Core.DIContainer;
using BoDi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.Mars.POM.Container
{
    [Binding]
    public class AppContainerConfig
    {
        [BeforeScenario(Order = 1)]
        public void BeforeScenario(IObjectContainer iobjectContainer)
        {

            iobjectContainer.RegisterTypeAs<AppConfiguration, IAppConfiguration>();
            iobjectContainer = CoreContainerConfig.SetAppContainer(iobjectContainer);

        }
    }
}
