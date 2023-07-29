using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;
using ZenithWeb.Drivers;
using ZenithWeb.Pages;
using NUnit.Framework;

namespace ZenithWeb.StepDefinitions
{
    [Binding]
    public class BankAccountPageStepDefinitions
    {

        BankAccountsPage bPage;
        private DriverHelper _driverHelper;
        private readonly ScenarioContext _scenarioContext;
        public BankAccountPageStepDefinitions(DriverHelper driverHelper, ScenarioContext scenarioContext)
        {
            _driverHelper = driverHelper;
            bPage = new BankAccountsPage(_driverHelper.Driver);
            _scenarioContext = scenarioContext;
        }

        [When(@"I hover over the Personal, Sme or corporate options")]
        public void WhenIHoverOverThePersonalSmeOrCorporateOptions()
        {
            WebDriverWait Wait = new WebDriverWait(_driverHelper.Driver, TimeSpan.FromSeconds(60));
            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(bPage.Personalmenu)));

            bPage.Hover(bPage.PersonalMenu);
        }

        [Then(@"the Bank account  menu should be displayed")]
        public void ThenTheBankAccountMenuShouldBeDisplayed()
        {
            WebDriverWait Wait = new WebDriverWait(_driverHelper.Driver, TimeSpan.FromSeconds(60));
            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(bPage.Personalmenu)));


            Assert.That(bPage.confirmBankAccountMenu, Is.True);
        }

        [When(@"I click on the Bank account  menu")]
        public void WhenIClickOnTheBankAccountMenu()
        {
            bPage.BankAccount.Click();
        }

        [Then(@"I should be redirected to theBank accounts page")]
        public void ThenIShouldBeRedirectedToTheBankAccountsPage()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driverHelper.Driver);

            fluentWait.Timeout = TimeSpan.FromSeconds(60);

            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            fluentWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(bPage.bankaccountLabel)));
            Assert.That(bPage.confirmBankAccountPage, Is.True);
        }
    }
}
