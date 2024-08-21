using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Mars.Core.Abstraction
{
    public enum LocatorType
    {
        Id,
        Name,
        TagName,
        ClassName,
        CssSelector,
        LinkText,
        PartialLinkText,
        XPath
    }
}
