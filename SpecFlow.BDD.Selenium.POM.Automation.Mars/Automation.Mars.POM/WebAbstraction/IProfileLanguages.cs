using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.Mars.POM.WebAbstraction
{
    public interface IProfileLanguages
    {
        public string GetGreeting();
        public string GetMyName();
        public void CleanUpLanguages();
        public void DeleteFirstLanguage();
        public int CountOfLanguages();
        public Table GetLanguagesTable();
        public void ClickAddNewButton();
        public void InputAddLanguageName(string name);
        public void SelectAddLanguageLevel(string level);
        public void ClickAddButton();
        public void ClickCancelButtonOfAddingLanguage();
        public void ClickCancelButtonOfUpdatingLanguage();
        public string GetPopupMessage();
        public void ClosePopupMessage();
        public void InputUpdateLanguageName(string name);
        public void SelectUpdateLanguageLevel(string level);
        public void ClickPenIcon();
        public void ClickUpdateButton();
        
    }
}
