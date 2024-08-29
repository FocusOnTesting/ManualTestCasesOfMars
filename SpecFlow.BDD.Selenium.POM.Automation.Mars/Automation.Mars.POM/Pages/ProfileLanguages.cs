using Automation.Mars.Core.Abstraction;
using Automation.Mars.Core.Base;
using Automation.Mars.Core.DriverContext;
using Automation.Mars.POM.WebAbstraction;
using BoDi;
using Microsoft.VisualBasic;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

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
        IAtBy byMyName => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]");
        IAtWebElement MyName => _idriver.FindElement(byMyName);
        IAtBy byLanguageTab => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]");
        IAtWebElement LanguageTab => _idriver.FindElement(byLanguageTab);
        IAtBy byAddNew => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div");
        IAtWebElement AddNew => _idriver.FindElement(byAddNew);
        IAtBy byAddLanguageName => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input");
        IAtWebElement AddLanguageName => _idriver.FindElement(byAddLanguageName);
        IAtBy byAddLanguageLevel => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select");
        IAtWebElement AddLanguageLevel => _idriver.FindElement(byAddLanguageLevel);
        IAtBy byAddButton => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]");
        IAtWebElement AddButton => _idriver.FindElement(byAddButton);
        IAtBy byCancelAddButton => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[2]");
        IAtWebElement CancelAddButton => _idriver.FindElement(byCancelAddButton);
        IAtBy byLanguageItems => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody");
        IAtWebElement LanguageItems => _idriver.FindElement(byLanguageItems);
        IAtBy byLanguageName(int index) => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + index + "]/tr/td[1]");
        IAtWebElement LanguageName(int index) => _idriver.FindElement(byLanguageName(index));
        IAtBy byLanguageLevel(int index) => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + index + "]/tr/td[2]");
        IAtWebElement LanguageLevel(int index) => _idriver.FindElement(byLanguageLevel(index));
        IAtBy byFirstLanguageName => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[1]");
        IAtWebElement FirstLanguageName => _idriver.FindElement(byFirstLanguageName);
        IAtBy byLastLanguagePenIcon => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i");
        IAtWebElement LastLanguagePenIcon => _idriver.FindElement(byLastLanguagePenIcon);
        IAtBy byUpdateLanguageName => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[1]/input");
        IAtWebElement UpdateLanguageName => _idriver.FindElement(byUpdateLanguageName);
        IAtBy byUpdateLanguageLevel => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[2]/select");
        IAtWebElement UpdateLanguageLevel => _idriver.FindElement(byUpdateLanguageLevel);
        IAtBy byUpdateButton => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td/div/span/input[1]");
        IAtWebElement UpdateButton => _idriver.FindElement(byUpdateButton);
        IAtBy byCancelUpdateButton => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td/div/span/input[2]");
        IAtWebElement CancelUpdateButton => _idriver.FindElement(byCancelUpdateButton);
        IAtBy byFirstLanguageRemoveIcon => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i");
        IAtWebElement FirstLanguageRemoveIcon => _idriver.FindElement(byFirstLanguageRemoveIcon);
        IAtBy byPopUpMsg => GetBy(LocatorType.XPath, "//div[contains(@class, \"ns-box-inner\")]");
        IAtWebElement PopUpMsg => _idriver.FindElement(byPopUpMsg);
        IAtBy byClosePopUp => GetBy(LocatorType.XPath, "//body/div[1]/a[1]");
        IAtWebElement ClosePopUp => _idriver.FindElement(byClosePopUp);

        string textNodeUserNameXPath = "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]/text()";

        public ProfileLanguages(IObjectContainer iobjectContainer)
            : base(iobjectContainer)
        {
            _iappConfiguration = iobjectContainer.Resolve<IAppConfiguration>();
            _idriver = iobjectContainer.Resolve<IDriver>();
        }

        public string GetGreeting()
        {

            Log.Information("Unknow page load status. This greeting string is: " + Greeting.GetText());
            _idriver.WaitForPageLoadAndTextNode(_idriver.GetWebDriver(), textNodeUserNameXPath);
            Log.Information("Page loaded fully. This greeting string is: " + Greeting.GetText());

            return Greeting.GetText();
        }

        public string GetMyName()
        {
            Log.Information("Unknow page load status. My name is: " + MyName.GetText());
            _idriver.WaitForPageLoadAndTextNode(_idriver.GetWebDriver(), textNodeUserNameXPath);
            Log.Information("Page loaded fully. My name is: " + MyName.GetText());

            return MyName.GetText();
        }

        public void CleanUpLanguages()
        {
            //How to make sure datas have been loaded fully.
            //Thread.Sleep(1000);
            Profile.Click();
            LanguageTab.Click();

            _idriver.WaitForPageLoadAndTextNode(_idriver.GetWebDriver(), textNodeUserNameXPath);

            int count = CountOfLanguages();
            Log.Information("------------Delete Stale Languages From Webpage------------");
            Log.Information("Check the number of existing languages: " + count);
            //Log.Information("The count of languages: " + _idriver.FindElementsCount(byLanguageItems));
            while (count > 0)
            {
                DeleteFirstLanguage();
                count--;
                Log.Information("Check the number of existing languages: " + count);
            }
        }

        public void DeleteFirstLanguage()
        {
            
            string firstItemName = FirstLanguageName.GetText();
            Log.Information("The name of first language is: " + firstItemName);

            FirstLanguageRemoveIcon.Click();

            String delXpath = "//div[contains(text(),'" + firstItemName + " has been deleted from your languages')]";
            ClosePopUp.Click();

            Log.Information("The deletion popup message is : " + PopUpMsg.GetText());

            // deal with a record has been deleted, but it is still on the page because of the system response.
            if (CountOfLanguages() > 0)
            {
                while (firstItemName != FirstLanguageName.GetText())
                {
                    break;
                }
            }
        }

        public int CountOfLanguages()
        {
            _idriver.WaitForPageLoadAndTextNode(_idriver.GetWebDriver(), textNodeUserNameXPath);
            return LanguageItems.NumberOfElement;
        }

        public Table GetLanguagesTable()
        {
            Log.Information("------------Get Languages Table From Webpage------------");
            _idriver.Refresh();
            Table table = new Table("Language", "Level");
            int row = CountOfLanguages();
            Log.Information("The number of languages on the page: " + row);

            for (int i = 1; i <= row; i++)
            {
                table.AddRow(LanguageName(i).GetText(), LanguageLevel(i).GetText());
                Log.Information("Get LanguageName: " + LanguageName(i).GetText());
                Log.Information("Get LanguageLevel: " + LanguageLevel(i).GetText());
            }

            return table;
        }

        public void ClickAddNewButton()
        {
            AddNew.Click();
        }

        public void InputAddLanguageName(string name)
        {
            AddLanguageName.SendKeys(name);
        }

        public void SelectAddLanguageLevel(string level)
        {
            AddLanguageLevel.SendKeys(level);
        }

        public void ClickAddButton()
        {
            AddButton.Click();
            Log.Information("The popup message is : " + PopUpMsg.GetText());
            _idriver.WaitForPageLoadAndTextNode(_idriver.GetWebDriver(), textNodeUserNameXPath);
        }

        public void ClickCancelButtonOfAddingLanguage()
        {
            CancelAddButton.Click();
        }

        public void ClickCancelButtonOfUpdatingLanguage()
        {
            CancelUpdateButton.Click();
        }

        public string GetPopupMessage()
        {
            return PopUpMsg.GetText();
        }

        public void ClosePopupMessage()
        {
            ClosePopUp.Click();
        }

        public void InputUpdateLanguageName(string name)
        {
            UpdateLanguageName.ClearText();
            UpdateLanguageName.SendKeys(name);
        }

        public void SelectUpdateLanguageLevel(string level)
        {
            UpdateLanguageLevel.SendKeys(level);
        }

        public void ClickPenIcon()
        {
            LastLanguagePenIcon.Click();
        }

        public void ClickUpdateButton()
        {
            UpdateButton.Click();
        }
    }
}
