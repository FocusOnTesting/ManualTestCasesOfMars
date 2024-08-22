using Automation.Mars.Core.Abstraction;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Mars.Core.Runner;
using Microsoft.Extensions.DependencyInjection;
using BoDi;
using Automation.Mars.Core.Selenium.LocalWebDrivers;

namespace Automation.Mars.Core.DriverContext
{
    public class Driver : IDriver
    {
        IChromeWebDriver _ichromeWebDriver;
        IFirefoxWebDriver _ifirefoxWebDriver;
        IWebDriver _iwebDriver;
        IObjectContainer _iobjectContainer;
        //public Driver(IChromeWebDriver ichromeWebDriver,IFirefoxWebDriver ifirefoxWebDriver,IObjectContainer iobjectContainer)
        public Driver(IObjectContainer iobjectContainer)
        {
            //_ichromeWebDriver = ichromeWebDriver;
            //_ifirefoxWebDriver = ifirefoxWebDriver;
            _ichromeWebDriver = iobjectContainer.Resolve<IChromeWebDriver>();
            _ifirefoxWebDriver = iobjectContainer.Resolve<IFirefoxWebDriver>();
            _iobjectContainer = iobjectContainer;
        }

        public IWebDriver GetWebDriver()
        {
            if (_iwebDriver == null)
            {
                GetNewWebDriver();
            }
            return _iwebDriver;
        }

        public void GetNewWebDriver()
        {
            IGlobalProperties _iglobalProperties = SpecflowRunner._iserviceProvider.GetRequiredService<IGlobalProperties>();
            switch (_iglobalProperties.browserType.ToLower())
            {
                case "chrome":
                    _iwebDriver = _ichromeWebDriver.GetChromeWebDriver();
                    break;
                case "firefox":
                    _iwebDriver = _ifirefoxWebDriver.GetFirefoxDriver();
                    break;

                default:
                    _iwebDriver = _ichromeWebDriver.GetChromeWebDriver();
                    break;
            }
        }

        public int FindElementsCount(IAtBy iatBy)
        {
            return GetWebDriver().FindElements(iatBy.By).Count;
        }
        public IAtWebElement FindElement(IAtBy iatBy)
        {
            IAtWebElement iatWebElement = _iobjectContainer.Resolve<IAtWebElement>();
            iatWebElement.Set(GetWebDriver(), iatBy);
            return iatWebElement;
        }
        public void CloseBrowser()
        {
            _iwebDriver.Quit();
        }

        public void NavigateTo(string url)
        {
            GetWebDriver().Navigate().GoToUrl(url);
        }
        public string GetPageTitle()
        {
            return GetWebDriver().Title;
        }

        public void GetNewTab()
        {

            GetWebDriver().SwitchTo().NewWindow(WindowType.Tab);
        }

        public void CloseCurrentBrowser()
        {
            GetWebDriver().Close();
        }

        public void SwitchToWindowWithHandle(string handle)
        {
            GetWebDriver().SwitchTo().Window(handle);
        }

        public void SwitchToWindowWithTitle(string title)
        {
            IList<string> windowhandles = GetWebDriver().WindowHandles;

            foreach (string handle in windowhandles)
            {
                if (GetWebDriver().SwitchTo().Window(handle).Title.Contains(title))
                {
                    break;
                }
            }
        }


        public void SwitchToFrameWithName(string frameName)
        {
            GetWebDriver().SwitchTo().Frame(frameName);
        }

        public void Maximize()
        {
            GetWebDriver().Manage().Window.Maximize();
        }

        public void ExecuteJavaScript(string script)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)GetWebDriver();
            js.ExecuteScript(script);
        }

        public string WebPageReadyState(string script)
        {
            string result = null;
            IJavaScriptExecutor js = (IJavaScriptExecutor)GetWebDriver();
            result = js.ExecuteScript(script).ToString();
            return result;
        }

        public void ScrollWithPixel()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)GetWebDriver();
            js.ExecuteScript("window.scrollBy(0,500)");
        }

        public void ScrollByheight()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)GetWebDriver();
            js.ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");
        }

        public void ScrollIntoView(IAtWebElement iatWebElement)
        {
            IWebElement iwebElement = iatWebElement.GetElement();

            IJavaScriptExecutor js = (IJavaScriptExecutor)GetWebDriver();
            js.ExecuteScript("agruments[0].scrollIntoView", iwebElement);
        }

        public string GetScreenShot()
        {
            return ((ITakesScreenshot)GetWebDriver()).GetScreenshot().AsBase64EncodedString;
        }
    }
}
