using Automation.Mars.POM.WebAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [When(@"Clean up stale languages")]
        public void WhenCleanUpStaleLanguages()
        {
            _iprofilePageLanguages.CleanUpLanguages();
        }

        [Then(@"No language is in the table")]
        public void ThenNoLanguageIsInTheTable()
        {
            Assert.Zero(_iprofilePageLanguages.NumberOfLanguages());
        }

        [When(@"Click Add New button")]
        public void WhenClickAddNewButton()
        {
        }

        [When(@"Input a language '([^']*)'")]
        public void WhenInputALanguage(string english)
        {
        }

        [When(@"Choose a language level '([^']*)'")]
        public void WhenChooseALanguageLevel(string fluent)
        {
        }

        [When(@"Click Add button")]
        public void WhenClickAddButton()
        {
        }

        [Then(@"A successful message pop is shown on the right top")]
        public void ThenASuccessfulMessagePopIsShownOnTheRightTop()
        {
        }

        [Then(@"Clean up test language datas")]
        public void ThenCleanUpTestLanguageDatas()
        {
        }

    }
}
