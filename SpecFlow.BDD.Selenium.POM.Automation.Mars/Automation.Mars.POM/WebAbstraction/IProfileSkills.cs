using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.Mars.POM.WebAbstraction
{
    public interface IProfileSkills
    {
        public string GetGreeting();
        public string GetMyName();
        public void CleanUpSkills();
        public void DeleteFirstSkill();
        public int CountOfSkills();
        public Table GetSkillsTable();
        public void ClickAddNewButton();
        public void InputAddSkillName(string name);
        public void SelectAddSkillLevel(string level);
        public void ClickAddButton();
        public void ClickCancelButtonOfAddSkill();
        public void ClickCancelButtonOfUpdateSkill();
        public string GetPopupMessage();
        public void ClosePopupMessage();
        public void InputUpdateSkillName(string name);
        public void SelectUpdateSkillLevel(string level);
        public void ClickPenIcon();
        public void ClickUpdateButton();
        
    }
}
