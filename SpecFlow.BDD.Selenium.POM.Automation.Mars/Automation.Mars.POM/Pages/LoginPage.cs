using Automation.Mars.Core.Abstraction;
using Automation.Mars.Core.Base;
using Automation.Mars.Core.DIContainer;
using Automation.Mars.POM.WebAbstraction;
using BoDi;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Mars.POM.Pages
{
    public class LoginPage : TestBase, ILoginPage
    {
        IAppConfiguration _iappConfiguration;
        IDriver _idriver;
        IAtBy bySignIn => GetBy(LocatorType.XPath, "//a[contains(text(),'Sign In')]");
        IAtWebElement SignIn => _idriver.FindElement(bySignIn);
        IAtBy byEmail => GetBy(LocatorType.Name, "email");
        IAtWebElement Email => _idriver.FindElement(byEmail);
        IAtBy byPassword => GetBy(LocatorType.Name, "password");
        IAtWebElement Password => _idriver.FindElement(byPassword);
        IAtBy byLogin => GetBy(LocatorType.XPath, "//button[contains(text(),'Login')]");
        IAtWebElement Login => _idriver.FindElement(byLogin);
        
        public LoginPage(IObjectContainer iobjectContainer)
            : base(iobjectContainer)
        {
            _iappConfiguration = iobjectContainer.Resolve<IAppConfiguration>();
            _idriver = iobjectContainer.Resolve<IDriver>();

            //string dr = _idriver.GetWebDriver().GetHashCode().ToString();
            //Log.Information("The hashcode of browser driver is: " + dr);
        }

        public void LoginWithDefaultCredentials()
        {
            string url = _iappConfiguration.GetConfiguration("url");
            _idriver.NavigateTo(url);
            SignIn.Click();
            Email.SendKeys(_iappConfiguration.GetConfiguration("email"));
            Password.Click();
            Password.SendKeys(_iappConfiguration.GetConfiguration("password"));
            Login.Click();

            
        }
    }
}
