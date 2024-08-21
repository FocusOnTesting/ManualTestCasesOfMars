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
        public void CleanUpLanguages();
        public int NumberOfLanguages();
    }
}
