using Automation.Mars.Core.Abstraction;
using Automation.Mars.Core.Base;
using Automation.Mars.Core.DriverContext;
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
    public class ProfileLanguages : TestBase, IProfileLanguages
    {
        IAppConfiguration _iappConfiguration;
        IDriver _idriver;
        IAtBy byGreeting => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span");
        IAtWebElement Greeting => _idriver.FindElement(byGreeting);
        IAtBy byLanguageItems => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody");
        IAtWebElement LanguageItems => _idriver.FindElement(byLanguageItems);
        IAtBy byFirstLanguageRemoveIcon => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i");
        IAtWebElement FirstLanguageRemoveIcon => _idriver.FindElement(byFirstLanguageRemoveIcon);
        IAtBy byDelPopUpMsg => GetBy(LocatorType.XPath, "//div[contains(text(),'has been deleted from your languages')]");
        IAtWebElement DelPopUpMsg => _idriver.FindElement(byDelPopUpMsg);
        IAtBy byClosePopUp => GetBy(LocatorType.XPath, "//body/div[1]/a[1]");
        IAtWebElement ClosePopUp => _idriver.FindElement(byDelPopUpMsg);


        public ProfileLanguages(IObjectContainer iobjectContainer)
            : base(iobjectContainer)
        {
            _iappConfiguration = iobjectContainer.Resolve<IAppConfiguration>();
            _idriver = iobjectContainer.Resolve<IDriver>();
        }

        public string GetGreeting()
        {
            Log.Information("This greeting string is: " + Greeting.GetText());
            return Greeting.GetText();
        }

        public void CleanUpLanguages()
        {
            //Thread.Sleep(2000);
            Greeting.IsDisplayed();
            int num = NumberOfLanguages();
            Log.Information("The number of languages:  " + num);
            //Log.Information("The number of languages: " + _idriver.FindElementsCount(byLanguageItems));
            while(num > 0)
            {
                DeleteFirstLanguage();
                num--;
                Log.Information("Check the number of existing languages: " + num);
            }
        }

        public int NumberOfLanguages()
        {
            return LanguageItems.NumberOfElement;
        }

        public void DeleteFirstLanguage()
        {
            FirstLanguageRemoveIcon.Click();
            while(DelPopUpMsg.IsDisplayed())
            {
                ClosePopUp.Click();
                break;
            }
        }

    }
}
