using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Mars.Core.Abstraction
{
    public interface IGlobalProperties
    {
        public void Configuration();
        public string dataSetLocation { get; set; }
        public string downloadedLocation { get; set; }
        public string browserType { get; }
        bool stepScreenShot { get; }

    }
}
