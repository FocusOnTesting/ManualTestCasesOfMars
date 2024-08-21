using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Mars.Core.Abstraction
{
    public interface IExtentFeatureReport
    {
        void InitializeExtentReport();
        AventStack.ExtentReports.ExtentReports GetExtentReport();
        void FlushExtent();
    }
}
