﻿using Automation.Mars.Core.Abstraction;
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
        IAtBy byPopUpMsg => GetBy(LocatorType.XPath, "//div[@class=\"ns-box-inner\" and contains(text(), \"your language\")]");
        IAtWebElement PopUpMsg => _idriver.FindElement(byPopUpMsg);
        IAtBy byClosePopUp => GetBy(LocatorType.XPath, "//body/div[1]/a[1]");
        IAtWebElement ClosePopUp => _idriver.FindElement(byClosePopUp);



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

            Log.Information("The deletion popup message is : " + PopUpMsg.GetText());

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
            ClosePopUp.Click();

            Log.Information("The deletion popup message is : " + PopUpMsg.GetText());

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
