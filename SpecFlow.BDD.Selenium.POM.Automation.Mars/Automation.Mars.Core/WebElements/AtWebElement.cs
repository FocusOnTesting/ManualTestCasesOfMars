using Automation.Mars.Core.Abstraction;
using Automation.Mars.Core.CustomException;
using Automation.Mars.Core.Runner;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Mars.Core.WebElements
{
    public class AtWebElement : IAtWebElement
    {
        IWebDriver _iwebDriver;
        IAtBy _iatBy;
        ILogging _ilogging;
        public void Set(IWebDriver iwebDriver, IAtBy iatBy)
        {
            _iwebDriver = iwebDriver;
            _iatBy = iatBy;
            _ilogging = SpecflowRunner._iserviceProvider.GetRequiredService<ILogging>();
        }

        int IAtWebElement.NumberOfElement => _iwebDriver.FindElements(_iatBy.By).Count();

        public IWebElement GetElement()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_iwebDriver, TimeSpan.FromSeconds(10));
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException)
                    , typeof(ElementNotVisibleException), typeof(ElementNotInteractableException));
                return wait.Until<IWebElement>(ExpectedConditions.ElementToBeClickable(_iatBy.By));
            }
            catch (Exception e)
            {
                _ilogging.Error("Element not clickable. " + e.Message);
                throw new AutomationException("Element is not clickable. " + e.Message);
            }
        }
        public void Click()
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    IWebElement iwebElement = GetElement();
                    iwebElement.Click();
                    break;
                }
                catch (StaleElementReferenceException st) { }
                catch (Exception e)
                {
                    _ilogging.Error("Error while clicking element. " + e.Message);
                    throw new AutomationException("Error while clicking element. " + e.Message);
                }
            }

        }

        public void SendKeys(string text)
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    IWebElement iwebElement = GetElement();
                    iwebElement.SendKeys(text);
                    break;
                }
                catch (StaleElementReferenceException ste) { }
                catch (Exception e)
                {
                    _ilogging.Error("Error while adding text. " + e.Message);
                    throw new AutomationException("Error while adding text. " + e.Message);
                }
            }
        }

        public void ClearText()
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    IWebElement webElement = GetElement();
                    webElement.SendKeys(Keys.Control + "a");
                    webElement.SendKeys(Keys.Delete);
                    break;
                }
                catch (StaleElementReferenceException st) { }
                catch (Exception e)
                {
                    _ilogging.Error("Error while clicking element: " + e.Message);
                    throw new AutomationException("Error while clicking element: " + e.Message);
                }
            }
        }

        public string GetText()
        {
            string text = string.Empty;
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    IWebElement webElement = GetElement();
                    text = webElement.Text;
                    break;
                }
                catch (StaleElementReferenceException st) { }
                catch (Exception e)
                {
                    _ilogging.Error("Error while clicking element: " + e.Message);
                    throw new AutomationException("Error while clicking element: " + e.Message);
                }
            }
            return text;
        }

        public string GetAttribute(string attributeName)
        {
            string text = string.Empty;
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    IWebElement webElement = GetElement();
                    text = webElement.GetAttribute(attributeName);
                    break;
                }
                catch (StaleElementReferenceException st) { }
                catch (Exception e)
                {
                    _ilogging.Error("Error while clicking element: " + e.Message);
                    throw new AutomationException("Error while clicking element: " + e.Message);
                }
            }
            return text;
        }

        public void MouseHover()
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    IWebElement webElement = GetElement();
                    Actions actions = new Actions(_iwebDriver);
                    actions.MoveToElement(webElement).Build().Perform();
                    break;
                }
                catch (StaleElementReferenceException st) { }
                catch (Exception e)
                {
                    _ilogging.Error("Error while hovering mouse on the element element: " + e.Message);
                    throw new AutomationException("Error while hovering mouse on the element: " + e.Message);
                }
            }
        }

        public bool IsDisplayed()
        {
            bool IsDisplayed = false;
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    IWebElement webElement = GetElement();
                    IsDisplayed = webElement.Displayed;
                    break;
                }
                catch (StaleElementReferenceException st) { }
                catch (Exception e)
                {
                    _ilogging.Error("Error while hovering mouse on the element element: " + e.Message);
                    throw new AutomationException("Error while hovering mouse on the element: " + e.Message);
                }
            }
            return IsDisplayed;
        }

        public void TextPresent()
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    IWebElement webElement = GetElement();
                    break;
                }
                catch (StaleElementReferenceException st) { }
                catch (Exception e)
                {
                    _ilogging.Error("Error while hovering mouse on the element element: " + e.Message);
                    throw new AutomationException("Error while hovering mouse on the element: " + e.Message);
                }
            }
        }

        public void DoubleClick()
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    IWebElement webElement = GetElement();
                    Actions actions = new Actions(_iwebDriver);
                    actions.ContextClick(webElement); ;
                    break;
                }
                catch (StaleElementReferenceException st) { }
                catch (Exception e)
                {
                    _ilogging.Error("Error while performing double click: " + e.Message);
                    throw new AutomationException("Error while performing double click: " + e.Message);
                }
            }
        }

        public void ClickWithJs()
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    IWebElement webElement = GetElement();
                    IJavaScriptExecutor ijavaScriptExecutor = (IJavaScriptExecutor)_iwebDriver;
                    ijavaScriptExecutor.ExecuteScript("arguments[0].click();", webElement);
                    break;
                }
                catch (StaleElementReferenceException st) { }
                catch (Exception e)
                {
                    _ilogging.Error("Error while clicking with javascript " + e.Message);
                    throw new AutomationException("Error while clicking with javascript. " + e.Message);
                }
            }
        }

    }
}
