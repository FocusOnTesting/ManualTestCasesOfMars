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
    public class ProfileSkills : TestBase, IProfileSkills
    {

        IAppConfiguration _iappConfiguration;
        IDriver _idriver;
        IAtBy byProfile => GetBy(LocatorType.XPath, "//body/div[@id='account-profile-section']/div[1]/section[1]/div[1]/a[2]");
        IAtWebElement Profile => _idriver.FindElement(byProfile);
        IAtBy byGreeting => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span");
        IAtWebElement Greeting => _idriver.FindElement(byGreeting);
        IAtBy byMyName => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]");
        IAtWebElement MyName => _idriver.FindElement(byMyName);
        IAtBy bySkillTab => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]");
        IAtWebElement SkillTab => _idriver.FindElement(bySkillTab);
        IAtBy byAddNew => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div");
        IAtWebElement AddNew => _idriver.FindElement(byAddNew);
        IAtBy byAddSkillName => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input");
        IAtWebElement AddSkillName => _idriver.FindElement(byAddSkillName);
        IAtBy byAddSkillLevel => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select");
        IAtWebElement AddSkillLevel => _idriver.FindElement(byAddSkillLevel);
        IAtBy byAddButton => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]");
        IAtWebElement AddButton => _idriver.FindElement(byAddButton);
        IAtBy byCancelAddButton => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[2]");
        IAtWebElement CancelAddButton => _idriver.FindElement(byCancelAddButton);
        IAtBy bySkillItems => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody");
        IAtWebElement SkillItems => _idriver.FindElement(bySkillItems);
        IAtBy bySkillName(int index) => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + index + "]/tr/td[1]");
        IAtWebElement SkillName(int index) => _idriver.FindElement(bySkillName(index));
        IAtBy bySkillLevel(int index) => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + index + "]/tr/td[2]");
        IAtWebElement SkillLevel(int index) => _idriver.FindElement(bySkillLevel(index));
        IAtBy byFirstSkillName => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td[1]");
        IAtWebElement FirstSkillName => _idriver.FindElement(byFirstSkillName);
        IAtBy byLastSkillPenIcon => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i");
        IAtWebElement LastSkillPenIcon => _idriver.FindElement(byLastSkillPenIcon);
        IAtBy byUpdateSkillName => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[1]/input");
        IAtWebElement UpdateSkillName => _idriver.FindElement(byUpdateSkillName);
        IAtBy byUpdateSkillLevel => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[2]/select");
        IAtWebElement UpdateSkillLevel => _idriver.FindElement(byUpdateSkillLevel);
        IAtBy byUpdateButton => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/span/input[1]");
        IAtWebElement UpdateButton => _idriver.FindElement(byUpdateButton);
        IAtBy byCancelUpdateButton => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/span/input[2]");
        IAtWebElement CancelUpdateButton => _idriver.FindElement(byCancelUpdateButton);
        IAtBy byFirstSkillRemoveIcon => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i");
        IAtWebElement FirstSkillRemoveIcon => _idriver.FindElement(byFirstSkillRemoveIcon);
        IAtBy bySkillRemoveIcon(int index) => GetBy(LocatorType.XPath, "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + index + "]/tr/td[3]/span[2]/i");
        IAtWebElement SkillRemoveIcon(int index) => _idriver.FindElement(bySkillRemoveIcon(index));
        IAtBy byPopUpMsg => GetBy(LocatorType.XPath, "//div[contains(@class, \"ns-box-inner\")]");
        IAtWebElement PopUpMsg => _idriver.FindElement(byPopUpMsg);
        IAtBy byClosePopUp => GetBy(LocatorType.XPath, "//body/div[1]/a[1]");
        IAtWebElement ClosePopUp => _idriver.FindElement(byClosePopUp);

        string textNodeUserNameXPath = "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]/text()";

        public ProfileSkills(IObjectContainer iobjectContainer)
            : base(iobjectContainer)
        {
            _iappConfiguration = iobjectContainer.Resolve<IAppConfiguration>();
            _idriver = iobjectContainer.Resolve<IDriver>();
        }

        public void OpenProfileSkills()
        {
            _idriver.NavigateTo("http://localhost:5000/Account/Profile");
            Profile.Click();
            SkillTab.Click();
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

        public void CleanUpSkills()
        {
            //How to make sure datas have been loaded fully.
            //Thread.Sleep(1000);
            Profile.Click();
            SkillTab.Click();

            _idriver.WaitForPageLoadAndTextNode(_idriver.GetWebDriver(), textNodeUserNameXPath);

            int count = CountOfSkills();
            Log.Information("------------Delete Stale Skills From Webpage------------");
            Log.Information("Check the number of existing Skills: " + count);
            //Log.Information("The count of Skills: " + _idriver.FindElementsCount(bySkillItems));
            while (count > 0)
            {
                DeleteFirstSkill();
                count--;
                Log.Information("Check the number of existing Skills: " + count);
            }
        }

        public void DeleteFirstSkill()
        {
            
            string firstItemName = FirstSkillName.GetText();
            Log.Information("The name of first Skill is: " + firstItemName);

            FirstSkillRemoveIcon.Click();

            String delXpath = "//div[contains(text(),'" + firstItemName + " has been deleted from your Skills')]";
            ClosePopUp.Click();

            Log.Information("The deletion popup message is : " + PopUpMsg.GetText());

            // deal with a record has been deleted, but it is still on the page because of the system response.
            if (CountOfSkills() > 0)
            {
                while (firstItemName != FirstSkillName.GetText())
                {
                    break;
                }
            }
        }

        public int CountOfSkills()
        {
            _idriver.WaitForPageLoadAndTextNode(_idriver.GetWebDriver(), textNodeUserNameXPath);
            return SkillItems.NumberOfElement;
        }

        public Table GetSkillsTable()
        {
            Log.Information("------------Get Skills Table From Webpage------------");
            _idriver.Refresh();
            Profile.Click();
            SkillTab.Click();
            Table table = new Table("Skill", "Level");
            int row = CountOfSkills();
            Log.Information("The number of Skills on the page: " + row);

            for (int i = 1; i <= row; i++)
            {
                table.AddRow(SkillName(i).GetText(), SkillLevel(i).GetText());
                Log.Information("Get SkillName: " + SkillName(i).GetText());
                Log.Information("Get SkillLevel: " + SkillLevel(i).GetText());
            }

            return table;
        }

        public void RemoveSkills(Table testTable)
        {
            Log.Information("------------Remove Test Data------------");
            foreach (var testTableRow in testTable.Rows)
            {
                Table skillTable = GetSkillsTable();
                for (int i = 0; i < skillTable.Rows.Count; i++)
                {
                    if (testTableRow["Skill"].Equals(skillTable.Rows[i]["Skill"]))
                    {
                        Log.Information("Found it");
                        SkillRemoveIcon(i + 1).Click();
                        ClosePopUp.Click();
                    }
                }
            }
        }

        public void ClickAddNewButton()
        {
            AddNew.Click();
        }

        public void InputAddSkillName(string name)
        {
            AddSkillName.SendKeys(name);
        }

        public void SelectAddSkillLevel(string level)
        {
            AddSkillLevel.SendKeys(level);
        }

        public void ClickAddButton()
        {
            AddButton.Click();
            Log.Information("The popup message is : " + PopUpMsg.GetText());
            _idriver.WaitForPageLoadAndTextNode(_idriver.GetWebDriver(), textNodeUserNameXPath);
        }

        public void ClickCancelButtonOfAddSkill()
        {
            CancelAddButton.Click();
        }

        public void ClickCancelButtonOfUpdateSkill()
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

        public void InputUpdateSkillName(string name)
        {
            UpdateSkillName.ClearText();
            UpdateSkillName.SendKeys(name);
        }

        public void SelectUpdateSkillLevel(string level)
        {
            UpdateSkillLevel.SendKeys(level);
        }

        public void ClickPenIcon()
        {
            LastSkillPenIcon.Click();
        }

        public void ClickUpdateButton()
        {
            UpdateButton.Click();
        }
    }
}
