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
using Automation.Mars.POM.Utilities;
using System.Threading.Channels;
using TechTalk.SpecFlow.Assist;
using Automation.Mars.POM.DataTables;

namespace Automation.Mars.POM.Steps
{
    [Binding]
    public class ProfileLanguagesSteps
    {
        private readonly IProfileLanguages _iprofilePageLanguages;
        private readonly ScenarioContext _sc;
        public ProfileLanguagesSteps(IProfileLanguages iprofilePageLanguages, ScenarioContext sc)
        {
            _iprofilePageLanguages = iprofilePageLanguages;
            _sc = sc;
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
            _iprofilePageLanguages.InputAddLanguageName(language);
        }

        [When(@"Choose a language level '([^']*)'")]
        public void WhenChooseALanguageLevel(string level)
        {
            _iprofilePageLanguages.SelectAddLanguageLevel(level);
        }

        [When(@"Click Add button")]
        public void WhenClickAddButton()
        {
            _iprofilePageLanguages.ClickAddButton();
        }        
        
        [When(@"Click cancel button")]
        public void WhenClickCancelButton()
        {
            _iprofilePageLanguages.ClickCancelButton();
        }



        [When(@"I add languages")]
        public void WhenIAddLanguages(Table table)
        {
            _sc["addLanguageTable"] = table;
            Serilog.Log.Information("addLanguageTable: " + _sc["addLanguageTable"].GetHashCode());
            //IDictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (TableRow row in table.Rows)
            {
                _iprofilePageLanguages.ClickAddNewButton();
                _iprofilePageLanguages.InputAddLanguageName(row["Language"]);
                _iprofilePageLanguages.SelectAddLanguageLevel(row["Level"]);
                _iprofilePageLanguages.ClickAddButton();
                _iprofilePageLanguages.ClosePopupMessage();
            }
        }

        [Given(@"I add languages")]
        public void GivenIAddLanguages(Table table)
        {
            _sc["addLanguageTable"] = table;
            Serilog.Log.Information("addLanguageTable: " + _sc["addLanguageTable"].GetHashCode());
            //IDictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (TableRow row in table.Rows)
            {
                _iprofilePageLanguages.ClickAddNewButton();
                _iprofilePageLanguages.InputAddLanguageName(row["Language"]);
                _iprofilePageLanguages.SelectAddLanguageLevel(row["Level"]);
                _iprofilePageLanguages.ClickAddButton();
                _iprofilePageLanguages.ClosePopupMessage();
            }
        }


        [Then(@"Languages should be added successfully")]
        public void LanguagesShouldBeAddedSuccessfully()
        {
            Table expectedTable = (Table)_sc["addLanguageTable"];
            Table actualTable = _iprofilePageLanguages.GetLanguagesTable();
            Assert.That(actualTable.ToProjection<Languages>().Except(expectedTable.ToProjection<Languages>()).Count(), Is.EqualTo(0));
            //Assert.IsTrue(TableComparer.AreTablesEqual(actualTable, expectedTable));
        }

        [Then(@"Clean up test languages")]
        public void ThenCleanUpTestLanguages(Table table)
        {
        }

        [When(@"I update the language '([^']*)' and level '([^']*)'")]
        public void WhenIUpdateTheLanguageAndLevel(string language, string level)
        {
            _iprofilePageLanguages.ClickPenIcon();
            _iprofilePageLanguages.InputUpdateLanguageName(language);
            _iprofilePageLanguages.SelectUpdateLanguageLevel(level);
            _iprofilePageLanguages.ClickUpdateButton();
        }

        [Then(@"The record is updated to new language '([^']*)' and level '([^']*)'")]
        public void ThenTheRecordIsUpdatedToNewLanguageAndLevel(string language, string level)
        {

        }

        [Then(@"Languages should not be added successfully")]
        public void LanguagesShouldNotBeAddedSuccessfully()
        {
            Table expectedTable;
            
            Table actualTable = _iprofilePageLanguages.GetLanguagesTable();

            if (actualTable.RowCount == 0 )
            {
                try
                {
                    Assert.Pass();
                }
                catch (Exception ex) { }
                return;
            }

            try
            {
                expectedTable = (Table)_sc["addLanguageTable"];
                Serilog.Log.Information("actualTable RowCount:" + actualTable.RowCount);
                Serilog.Log.Information("expectedTable RowCount:" + expectedTable.RowCount);
                
                Serilog.Log.Information("actualTable Projection: " + string.Join(", ", actualTable.ToProjection<Languages>()));
                Serilog.Log.Information("expectedTable Projection: " + string.Join(", ", expectedTable.ToProjection<Languages>()));
                Serilog.Log.Information("Diff: " + actualTable.ToProjection<Languages>().Except(expectedTable.ToProjection<Languages>()).Count());

                Serilog.Log.Information("the hashcode of actualTable: " + actualTable.GetHashCode());
                Serilog.Log.Information("the hashcode of expectedTable: " + expectedTable.GetHashCode());

                //Assert.That(actualTable.ToProjection<Languages>().Except(expectedTable.ToProjection<Languages>()).Count(), Is.GreaterThan(0));
                Assert.IsFalse(TableComparer.AreTablesEqual(actualTable, expectedTable));
            }
            catch (KeyNotFoundException e)
            {
                try
                {
                    Assert.Pass();
                }
                catch (Exception ex) { }
                return;
            }
        }

    }
}
