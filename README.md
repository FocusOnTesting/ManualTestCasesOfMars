# SpecFlow.BDD.Selenium.POM.Automation.Mars
## Instructions
The process of building this Automation Framework is as following.

https://focusontesting.sg.larksuite.com/wiki/AiJuwvX6tiFeFnkYcBglbZIgg8d

## Introductions
### Automation.Mars.Core
Core project implements the basic framework.
1. Global settings function, e.g. Browser type, browser version, step screenshot switch.
2. Default variables settings function.
3. Capsulations of Selenium WeDriver, WebElement, By.
4. Hooks of TestRun, Feature
5. Test results HTML reports.
6. Dependency Injection implementation.
7. This project can be integrated as a NuGet package to import to differet automation solution.

### Automation.Mars.POM
POM project implements the Page Object Model.
1. App configuration settings, e.g. Application Url, account.
2. Hooks of Scenario, Step
3. Web pages, page steps.

### Automation.Mars.Test
Test project implements test related function.
1. Test resources including global setttings files, default variables settings files.
2. Test cases feature files.
3. Test results HTML reports files.