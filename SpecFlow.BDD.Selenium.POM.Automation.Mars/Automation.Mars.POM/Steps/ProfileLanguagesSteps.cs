using Automation.Mars.Core.Abstraction;
using Automation.Mars.POM.WebAbstraction;
using AventStack.ExtentReports.Model;
using Serilog;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.Mars.POM.Steps
{
    [Binding]
    public class ProfileLanguagesSteps
    {
        IProfileLanguages _iprofilePageLanguages;
        public ProfileLanguagesSteps(IProfileLanguages iprofilePageLanguages)
        {
            _iprofilePageLanguages = iprofilePageLanguages;
        }

        [When(@"Clean up languages")]
        public void WhenCleanUpLanguages()
        {
            _iprofilePageLanguages.CleanUpLanguages();
        }

        [Then(@"No language is in the table")]
        public void ThenNoLanguageIsInTheTable()
        {
            Assert.Zero(_iprofilePageLanguages.CountOfLanguages());
        }

        [When(@"Click Add New button")]
        public void WhenClickAddNewButton()
        {
            _iprofilePageLanguages.ClickAddNewButton();
        }

        [When(@"Input a language '([^']*)'")]
        public void WhenInputALanguage(string language)
        {
            _iprofilePageLanguages.InputLanguageName(language);
        }

        [When(@"Choose a language level '([^']*)'")]
        public void WhenChooseALanguageLevel(string level)
        {
            _iprofilePageLanguages.SelectLanguageLevel(level);
        }

        [When(@"Click Add button")]
        public void WhenClickAddButton()
        {
            _iprofilePageLanguages.ClickAddButton();
        }

        [When(@"Add Languages")]
        public void WhenAddLanguages(Table table)
        {
            IDictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (TableRow row in table.Rows)
            {
                _iprofilePageLanguages.ClickAddNewButton();
                _iprofilePageLanguages.InputLanguageName(row[0]);
                _iprofilePageLanguages.SelectLanguageLevel(row[1]);
                _iprofilePageLanguages.ClickAddButton();
            }
        }


        [Then(@"A successful message pop is shown on the right top")]
        public void ThenASuccessfulMessagePopIsShownOnTheRightTop()
        {

        }

        [Then(@"Clean up test languages")]
        public void ThenCleanUpTestLanguages(Table table)
        {

        }

    }
}
