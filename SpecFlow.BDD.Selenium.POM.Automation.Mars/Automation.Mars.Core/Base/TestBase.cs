using Automation.Mars.Core.Abstraction;
using BoDi;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Mars.Core.Base
{
    public class TestBase
    {
        IObjectContainer _iobjectContainer;
        public TestBase(IObjectContainer objectContainer)
        {
            _iobjectContainer = objectContainer;
        }

        public IAtBy GetBy(LocatorType type, string value)
        {
            By by;
            IAtBy iatBy = _iobjectContainer.Resolve<IAtBy>();
            switch (type)
            {
                case LocatorType.Id:
                    by = By.Id(value);
                    break;
                case LocatorType.Name:
                    by = By.Name(value);
                    break;
                case LocatorType.TagName:
                    by = By.TagName(value);
                    break;
                case LocatorType.ClassName:
                    by = By.ClassName(value);
                    break;
                case LocatorType.CssSelector:
                    by = By.CssSelector(value);
                    break;
                case LocatorType.LinkText:
                    by = By.LinkText(value);
                    break;
                case LocatorType.PartialLinkText:
                    by = By.PartialLinkText(value);
                    break;
                case LocatorType.XPath:
                    by = By.XPath(value);
                    break;
                default:
                    by = By.XPath(value);
                    break;
            }
            iatBy.By = by;
            return iatBy;

        }
    }
}
