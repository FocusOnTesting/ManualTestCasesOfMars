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
        IAtBy byProfile => GetBy(LocatorType.XPath, "//body/div[@id='account-profile-section']/div[1]/section[1]/div[1]/a[2]");
        IAtWebElement Profile => _idriver.FindElement(byProfile);
        IAtBy byGreeting => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span");
        IAtWebElement Greeting => _idriver.FindElement(byGreeting);
        IAtBy byLanguageTab => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]");
        IAtWebElement LanguageTab => _idriver.FindElement(byLanguageTab);
        IAtBy byAddNew => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div");
        IAtWebElement AddNew => _idriver.FindElement(byAddNew);
        IAtBy byLanguageNameText => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input");
        IAtWebElement LanguageNameText => _idriver.FindElement(byLanguageNameText);
        IAtBy byLanguageLevelSelection => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select");
        IAtWebElement LanguageLevelSelection => _idriver.FindElement(byLanguageLevelSelection);
        IAtBy byAddButton => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]");
        IAtWebElement AddButton => _idriver.FindElement(byAddButton);
        IAtBy byCancelButton => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[2]");
        IAtWebElement CancelButton => _idriver.FindElement(byCancelButton);
        IAtBy byLanguageItems => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody");
        IAtWebElement LanguageItems => _idriver.FindElement(byLanguageItems);
        IAtBy byFirstLanguageName => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[1]");
        IAtWebElement FirstLanguageName => _idriver.FindElement(byFirstLanguageName);
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

        public void ClickAddNewButton()
        {
            AddNew.Click();
        }

        public void InputLanguageName(string name)
        {
            LanguageNameText.SendKeys(name);
        }

        public void SelectLanguageLevel(string level)
        {
            LanguageLevelSelection.SendKeys(level);
        }

        public void ClickAddButton()
        {
            AddButton.Click();
        }

        public void CleanUpLanguages()
        {
            //How to make sure datas have been loaded fully.
            //Thread.Sleep(1000);
            Profile.Click();
            LanguageTab.Click();

            string pageLoadStatus;
            do
            {
                pageLoadStatus = _idriver.WebPageReadyState("return document.readyState");
                Log.Information("The language page load status is: " + pageLoadStatus);

            } while (!pageLoadStatus.Equals("complete"));

            int count = CountOfLanguages();
            Log.Information("Check the number of existing languages: " + count);
            //Log.Information("The count of languages: " + _idriver.FindElementsCount(byLanguageItems));
            while(count > 0)
            {
                DeleteFirstLanguage();
                count--;
                Log.Information("Check the number of existing languages: " + count);
            }
        }

        public int CountOfLanguages()
        {
            return LanguageItems.NumberOfElement;
        }

        public void DeleteFirstLanguage()
        {
            string firstItemName = FirstLanguageName.GetText();
            Log.Information("The name of first language is: " + firstItemName);

            FirstLanguageRemoveIcon.Click();

            String delXpath = "//div[contains(text(),'" + firstItemName + " has been deleted from your languages')]";
            IAtBy byDelPopUpMsg = GetBy(LocatorType.XPath, delXpath);
            IAtWebElement DelPopUpMsg = _idriver.FindElement(byDelPopUpMsg);
            bool isDisplayed = DelPopUpMsg.IsDisplayed();

            Log.Information("Check if deletion popup message is displayed: " + isDisplayed);
            Log.Information("The deletion popup message is : " + DelPopUpMsg.GetText());

            if (CountOfLanguages() > 0)
            {
                while (firstItemName != FirstLanguageName.GetText())
                {
                    break;
                }
            }

        }

    }
}
