using Automation.Mars.POM.Pages;
using Automation.Mars.POM.WebAbstraction;
using System;
using TechTalk.SpecFlow;

namespace Automation.Mars.POM.Test
{
    [Binding]
    public class LoginSteps
    {
        ILoginPage _iloginPage;
        IProfileLanguages _iprofilePage_Languages;
        public LoginSteps(ILoginPage iloginPage, IProfileLanguages iprofilePage_Languages)
        {
            _iloginPage = iloginPage;
            _iprofilePage_Languages = iprofilePage_Languages;
        }

        [Given(@"Login with default credentials")]
        public void GivenLoginWithDefaultCredentials()
        {
            _iloginPage.LoginWithDefaultCredentials();
        }


        [Then(@"Login successfully")]
        public void ThenLoginSuccessfully()
        {
            string greeting = string.Empty;
            string myName = string.Empty;
            greeting = _iprofilePage_Languages.GetGreeting();
            myName = _iprofilePage_Languages.GetMyName();

            Assert.That(greeting, Is.EqualTo("Hi Jay"));
            Assert.That(myName, Is.EqualTo("Jay P"));
        }


    }
}
