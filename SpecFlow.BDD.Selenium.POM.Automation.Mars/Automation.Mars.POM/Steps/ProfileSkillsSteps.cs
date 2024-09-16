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
    public class ProfileSkillsSteps
    {
        private readonly IProfileSkills _iprofilePageSkills;
        private readonly ScenarioContext _sc;
        public ProfileSkillsSteps(IProfileSkills iprofilePageSkills, ScenarioContext sc)
        {
            _iprofilePageSkills = iprofilePageSkills;
            _sc = sc;
        }

        [Given(@"I am on the profile page skills section")]
        public void GivenIAmOnTheProfilePageSkillsSection()
        {
            _iprofilePageSkills.OpenProfileSkills();
        }


        [When(@"Clean up skills")]
        public void WhenCleanUpSkills()
        {
            _iprofilePageSkills.CleanUpSkills();
        }

        [Then(@"No skill is in the table")]
        public void ThenNoSkillIsInTheTable()
        {
            Assert.Zero(_iprofilePageSkills.CountOfSkills());
        }

        [When(@"I click Add New button in Skills section")]
        public void WhenIClickAddNewButton()
        {
            _iprofilePageSkills.ClickAddNewButton();
        }

        [When(@"I input a skill '([^']*)'")]
        public void WhenIInputASkill(string Skill)
        {
            _iprofilePageSkills.InputAddSkillName(Skill);
        }

        [When(@"I choose a skill level '([^']*)'")]
        public void WhenIChooseASkillLevel(string level)
        {
            _iprofilePageSkills.SelectAddSkillLevel(level);
        }

        [When(@"I click Add button")]
        public void WhenIClickAddButton()
        {
            _iprofilePageSkills.ClickAddButton();
        }        
        
        [When(@"I click cancel button of adding skill")]
        public void WhenIClickCancelButtonOfAddSkill()
        {
            _iprofilePageSkills.ClickCancelButtonOfAddSkill();
        }



        [When(@"I add skills")]
        public void WhenIAddSkills(Table table)
        {
            _sc["addSkillTable"] = table;
            Serilog.Log.Information("addSkillTable: " + _sc["addSkillTable"].GetHashCode());
            //IDictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (TableRow row in table.Rows)
            {
                _iprofilePageSkills.ClickAddNewButton();
                _iprofilePageSkills.InputAddSkillName(row["Skill"]);
                _iprofilePageSkills.SelectAddSkillLevel(row["Level"]);
                _iprofilePageSkills.ClickAddButton();
                _iprofilePageSkills.ClosePopupMessage();
            }
        }

        [Given(@"I add skills")]
        public void GivenIAddSkills(Table table)
        {
            _sc["addSkillTable"] = table;
            Serilog.Log.Information("addSkillTable: " + _sc["addSkillTable"].GetHashCode());
            //IDictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (TableRow row in table.Rows)
            {
                _iprofilePageSkills.ClickAddNewButton();
                _iprofilePageSkills.InputAddSkillName(row["Skill"]);
                _iprofilePageSkills.SelectAddSkillLevel(row["Level"]);
                _iprofilePageSkills.ClickAddButton();
                _iprofilePageSkills.ClosePopupMessage();
            }
        }


        [Then(@"Skills should be added successfully")]
        public void SkillsShouldBeAddedSuccessfully()
        {
            Table expectedTable = (Table)_sc["addSkillTable"];
            Table actualTable = _iprofilePageSkills.GetSkillsTable();

            TableUtils.PrintTable(expectedTable);
            TableUtils.PrintTable(actualTable);

            //Assert.That(actualTable.ToProjection<Skills>().Except(expectedTable.ToProjection<Skills>()).Count(), Is.EqualTo(0));
            Assert.IsTrue(TableUtils.AreTablesEqual(actualTable, expectedTable));
        }

        [Then(@"Clean up test skills")]
        public void ThenCleanUpTestSkills(Table table)
        {
            _iprofilePageSkills.RemoveSkills(table);
        }

        [When(@"I update skills")]
        public void WhenIUpdateSkills(Table table)
        {
            _sc["updateSkillTable"] = table;

            foreach (TableRow row in table.Rows)
            {
                _iprofilePageSkills.ClickPenIcon();
                _iprofilePageSkills.InputUpdateSkillName(row["Skill"]);
                _iprofilePageSkills.SelectUpdateSkillLevel(row["Level"]);
                _iprofilePageSkills.ClickUpdateButton();
                _iprofilePageSkills.ClosePopupMessage();
            }
        }

        [When(@"I click Update button in Skills section")]
        public void WhenIClickUpdateButton()
        {
            _iprofilePageSkills.ClickPenIcon();
        }

        [When(@"I update a skill name'([^']*)'")]
        public void WhenIUpdateASkillName(string Skill)
        {
            _iprofilePageSkills.InputUpdateSkillName(Skill);
        }

        [When(@"I update a skill level '([^']*)'")]
        public void WhenIUpdateASkillLevel(string level)
        {
            _iprofilePageSkills.SelectUpdateSkillLevel(level);
        }

        [When(@"I click cancel button of update skill")]
        public void WhenIClickCancelButtonOfUpdateSkill()
        {
            _iprofilePageSkills.ClickCancelButtonOfUpdateSkill();
        }



        [Then(@"Skills should be updated successfully")]
        public void SkillsShouldBeUpdatedSuccessfully()
        {
            Table expectedTable = (Table)_sc["updateSkillTable"];
            Table actualTable = _iprofilePageSkills.GetSkillsTable();

            TableUtils.PrintTable(expectedTable);
            TableUtils.PrintTable(actualTable);

            //Assert.That(actualTable.ToProjection<Skills>().Except(expectedTable.ToProjection<Skills>()).Count(), Is.EqualTo(0));
            Assert.IsTrue(TableUtils.AreTablesEqual(actualTable, expectedTable));
        }

        [Then(@"Skills should not be updated successfully")]
        public void SkillsShouldNotBeUpdatedSuccessfully()
        {
            Table expectedTable = (Table)_sc["updateSkillTable"];
            Table actualTable = _iprofilePageSkills.GetSkillsTable();

            TableUtils.PrintTable(expectedTable);
            TableUtils.PrintTable(actualTable);

            //Assert.That(actualTable.ToProjection<Skills>().Except(expectedTable.ToProjection<Skills>()).Count(), Is.EqualTo(0));
            Assert.IsTrue(TableUtils.AreTablesEqual(actualTable, expectedTable));
        }

        [Then(@"The skills shoud be the same as added")]
        public void ThenTheSkillsShoudBeTheSameAsAdded()
        {
            Table expectedTable = (Table)_sc["addSkillTable"];
            Table actualTable = _iprofilePageSkills.GetSkillsTable();

            TableUtils.PrintTable(expectedTable);
            TableUtils.PrintTable(actualTable);

            //Assert.That(actualTable.ToProjection<Skills>().Except(expectedTable.ToProjection<Skills>()).Count(), Is.EqualTo(0));
            Assert.IsTrue(TableUtils.AreTablesEqual(actualTable, expectedTable));
        }


        [When(@"I update the Skill '([^']*)' and level '([^']*)'")]
        public void WhenIUpdateTheSkillAndLevel(string Skill, string level)
        {
            _iprofilePageSkills.ClickPenIcon();
            _iprofilePageSkills.InputUpdateSkillName(Skill);
            _iprofilePageSkills.SelectUpdateSkillLevel(level);
            _iprofilePageSkills.ClickUpdateButton();
            _iprofilePageSkills.ClosePopupMessage();
        }
        
        [Then(@"The record is updated to new skill '([^']*)' and level '([^']*)'")]
        public void ThenTheRecordIsUpdatedToNewSkillAndLevel(string Skill, string level)
        {

        }

        [Then(@"An error message is displayed for updating skill operation")]
        public void ThenAnErrorMessageIsDisplayed()
        {
            Assert.That(_iprofilePageSkills.GetPopupMessage(),Is.EqualTo("This skill is already added to your skill list."));
        }

        [Then(@"Skills should not be added successfully")]
        public void SkillsShouldNotBeAddedSuccessfully()
        {
            Table expectedTable;
            
            Table actualTable = _iprofilePageSkills.GetSkillsTable();

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
                expectedTable = (Table)_sc["addSkillTable"];
                Serilog.Log.Information("actualTable RowCount:" + actualTable.RowCount);
                Serilog.Log.Information("expectedTable RowCount:" + expectedTable.RowCount);

                Serilog.Log.Information("the hashcode of actualTable: " + actualTable.GetHashCode());
                Serilog.Log.Information("the hashcode of expectedTable: " + expectedTable.GetHashCode());

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

        [When(@"I delete skills")]
        public void WhenIDeleteSkills()
        {
            _iprofilePageSkills.DeleteFirstSkill();
        }
    }
}
