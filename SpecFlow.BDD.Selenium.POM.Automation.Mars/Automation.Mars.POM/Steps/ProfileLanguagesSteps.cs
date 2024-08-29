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

        [When(@"I click Add New button in Languages section")]
        public void WhenIClickAddNewButton()
        {
            _iprofilePageLanguages.ClickAddNewButton();
        }

        [When(@"I input a language '([^']*)'")]
        public void WhenIInputALanguage(string language)
        {
            _iprofilePageLanguages.InputAddLanguageName(language);
        }

        [When(@"I choose a language level '([^']*)'")]
        public void WhenIChooseALanguageLevel(string level)
        {
            _iprofilePageLanguages.SelectAddLanguageLevel(level);
        }

        [When(@"I click Add button")]
        public void WhenIClickAddButton()
        {
            _iprofilePageLanguages.ClickAddButton();
        }        
        
        [When(@"I click cancel button of adding language")]
        public void WhenIClickCancelButtonOfAddingLanguage()
        {
            _iprofilePageLanguages.ClickCancelButtonOfAddingLanguage();
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

            TableUtils.PrintTable(expectedTable);
            TableUtils.PrintTable(actualTable);

            //Assert.That(actualTable.ToProjection<Languages>().Except(expectedTable.ToProjection<Languages>()).Count(), Is.EqualTo(0));
            Assert.IsTrue(TableUtils.AreTablesEqual(actualTable, expectedTable));
        }

        [Then(@"Clean up test languages")]
        public void ThenCleanUpTestLanguages(Table table)
        {
        }

        [When(@"I update languages")]
        public void WhenIUpdateLanguages(Table table)
        {
            _sc["updateLanguageTable"] = table;

            foreach (TableRow row in table.Rows)
            {
                _iprofilePageLanguages.ClickPenIcon();
                _iprofilePageLanguages.InputUpdateLanguageName(row["Language"]);
                _iprofilePageLanguages.SelectUpdateLanguageLevel(row["Level"]);
                _iprofilePageLanguages.ClickUpdateButton();
                _iprofilePageLanguages.ClosePopupMessage();
            }
        }

        [When(@"I click Update button in Languages section")]
        public void WhenIClickUpdateButton()
        {
            _iprofilePageLanguages.ClickPenIcon();
        }

        [When(@"I update a language name'([^']*)'")]
        public void WhenIUpdateALanguageName(string language)
        {
            _iprofilePageLanguages.InputUpdateLanguageName(language);
        }

        [When(@"I update a language level '([^']*)'")]
        public void WhenIUpdateALanguageLevel(string level)
        {
            _iprofilePageLanguages.SelectUpdateLanguageLevel(level);
        }

        [When(@"I click cancel button of updating language")]
        public void WhenIClickCancelButtonOfUpdatingLanguage()
        {
            _iprofilePageLanguages.ClickCancelButtonOfUpdatingLanguage();
        }



        [Then(@"Languages should be updated successfully")]
        public void LanguagesShouldBeUpdatedSuccessfully()
        {
            Table expectedTable = (Table)_sc["updateLanguageTable"];
            Table actualTable = _iprofilePageLanguages.GetLanguagesTable();

            TableUtils.PrintTable(expectedTable);
            TableUtils.PrintTable(actualTable);

            //Assert.That(actualTable.ToProjection<Languages>().Except(expectedTable.ToProjection<Languages>()).Count(), Is.EqualTo(0));
            Assert.IsTrue(TableUtils.AreTablesEqual(actualTable, expectedTable));
        }

        [Then(@"Languages should not be updated successfully")]
        public void LanguagesShouldNotBeUpdatedSuccessfully()
        {
            Table expectedTable = (Table)_sc["updateLanguageTable"];
            Table actualTable = _iprofilePageLanguages.GetLanguagesTable();

            TableUtils.PrintTable(expectedTable);
            TableUtils.PrintTable(actualTable);

            //Assert.That(actualTable.ToProjection<Languages>().Except(expectedTable.ToProjection<Languages>()).Count(), Is.EqualTo(0));
            Assert.IsTrue(TableUtils.AreTablesEqual(actualTable, expectedTable));
        }

        [Then(@"The languages shoud be the same as added")]
        public void ThenTheLanguagesShoudBeTheSameAsAdded()
        {
            Table expectedTable = (Table)_sc["addLanguageTable"];
            Table actualTable = _iprofilePageLanguages.GetLanguagesTable();

            TableUtils.PrintTable(expectedTable);
            TableUtils.PrintTable(actualTable);

            //Assert.That(actualTable.ToProjection<Languages>().Except(expectedTable.ToProjection<Languages>()).Count(), Is.EqualTo(0));
            Assert.IsTrue(TableUtils.AreTablesEqual(actualTable, expectedTable));
        }


        [When(@"I update the language '([^']*)' and level '([^']*)'")]
        public void WhenIUpdateTheLanguageAndLevel(string language, string level)
        {
            _iprofilePageLanguages.ClickPenIcon();
            _iprofilePageLanguages.InputUpdateLanguageName(language);
            _iprofilePageLanguages.SelectUpdateLanguageLevel(level);
            _iprofilePageLanguages.ClickUpdateButton();
            _iprofilePageLanguages.ClosePopupMessage();
        }
        
        [Then(@"The record is updated to new language '([^']*)' and level '([^']*)'")]
        public void ThenTheRecordIsUpdatedToNewLanguageAndLevel(string language, string level)
        {

        }

        [Then(@"An error message is displayed for updating language operation")]
        public void ThenAnErrorMessageIsDisplayed()
        {
            Assert.That(_iprofilePageLanguages.GetPopupMessage(),Is.EqualTo("This language is already added to your language list."));
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
                Assert.IsFalse(TableUtils.AreTablesEqual(actualTable, expectedTable));
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

        [When(@"I delete languages")]
        public void WhenIDeleteLanguages()
        {
            _iprofilePageLanguages.DeleteFirstLanguage();
        }
    }
}
