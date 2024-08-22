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
        public void InputLanguageName(string name);
        public void SelectLanguageLevel(string level);
        public void ClickAddButton();
        public void CleanUpLanguages();
        public int CountOfLanguages();
    }
}
