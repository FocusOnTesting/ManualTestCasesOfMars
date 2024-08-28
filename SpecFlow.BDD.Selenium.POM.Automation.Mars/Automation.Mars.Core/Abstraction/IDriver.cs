using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Mars.Core.Abstraction
{
    public interface IDriver
    {
        IWebDriver GetWebDriver();
        void CloseBrowser();
        public void Refresh();
        IAtWebElement FindElement(IAtBy iatBy);
        void NavigateTo(string url);
        string GetPageTitle();
        void GetNewTab();
        void CloseCurrentBrowser();
        void SwitchToWindowWithHandle(string handle);
        void SwitchToWindowWithTitle(string title);
        void SwitchToFrameWithName(string frameName);
        void Maximize();
        void ExecuteJavaScript(string script);
        public void WaitForPageLoadAndTextNode(IWebDriver driver, string xpath, int timeoutInSeconds = 10);
        void ScrollWithPixel();
        void ScrollByheight();
        void ScrollIntoView(IAtWebElement iatWebElement);
        string GetScreenShot();
        int FindElementsCount(IAtBy iatBy);
    }
}
