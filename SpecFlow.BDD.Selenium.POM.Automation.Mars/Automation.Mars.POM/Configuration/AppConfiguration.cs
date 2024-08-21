using Automation.Mars.POM.WebAbstraction;
using Automation.Mars.Core.Abstraction;
using Automation.Mars.Core.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;


namespace Automation.Mars.POM.Configuration
{
    public class AppConfiguration : IAppConfiguration
    {
        IConfiguration _iconfiguration;
        public AppConfiguration()
        {
            IDefaultVariables idefaultVariables = SpecflowRunner._iserviceProvider.GetRequiredService<IDefaultVariables>();
            _iconfiguration = new ConfigurationBuilder().AddJsonFile(idefaultVariables.getAppplicationConfigjson).Build();
        }

        public string GetConfiguration(string key)
        {
            return _iconfiguration[key];
        }
    }
}
