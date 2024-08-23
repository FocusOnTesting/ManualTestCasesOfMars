using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Mars.POM.WebAbstraction
{
    public interface IProfileLanguages
    {
        public string GetGreeting();
        public void ClickAddNewButton();
        public void InputAddLanguageName(string name);
        public void SelectAddLanguageLevel(string level);
        public void ClickAddButton();
        public void ClickPenIcon();
        public void InputUpdateLanguageName(string name);
        public void SelectUpdateLanguageLevel(string level);
        public void ClickUpdateButton();
        public void CleanUpLanguages();
        public int CountOfLanguages();
    }
}
