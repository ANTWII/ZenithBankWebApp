using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ZenithWeb.Drivers;
using ZenithWeb.Pages;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace ZenithWeb.StepDefinitions
{
    [Binding]
    public class PersonalPageStepDefinitions
    {
        PersonalPage pPage;
        private DriverHelper _driverHelper;
        private readonly ScenarioContext _scenarioContext;
        public PersonalPageStepDefinitions(DriverHelper driverHelper, ScenarioContext scenarioContext)
        {
            _driverHelper = driverHelper;
            pPage = new PersonalPage(_driverHelper.Driver);
            _scenarioContext = scenarioContext;
        }
       
        [When(@"I hover over the Internet Banking option")]
        public void WhenIHoverOverTheInternetBankingOption()
        {
            WebDriverWait Wait = new WebDriverWait(_driverHelper.Driver, TimeSpan.FromSeconds(60));
            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(pPage.internetBmenu)));

            pPage.Hover(pPage.internetBankingMenu);
        }


        [Then(@"the Personal menu should be displayed")]
        public void ThenThePersonalMenuShouldBeDisplayed()
        {
            WebDriverWait Wait = new WebDriverWait(_driverHelper.Driver, TimeSpan.FromSeconds(60));
            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(pPage.Personalmenu)));


            Assert.That(pPage.confirmPersonalMenuExist, Is.True);
        }



        [When(@"I click on the Personal menu")]
        public void WhenIClickOnThePersonalMenu()
        {
            pPage.PersonalMenu.Click();
        }


        

        [Then(@"I should be redirected to the Personal Internet Banking login page")]
        public void ThenIShouldBeRedirectedToThePersonalInternetBankingLoginPage()
        {

            // Store the handle of the currently active browser window
            string mainWindowHandle = _driverHelper.Driver.CurrentWindowHandle;


            // Retrieve the handles of all currently open browser windows
            ReadOnlyCollection<string> windowHandles = _driverHelper.Driver.WindowHandles;
            // Loop over each window handle

            foreach (string windowHandle in windowHandles)
            {
                if (windowHandle != mainWindowHandle)
                {
                    // Switch the WebDriver context to the new window

                    _driverHelper.Driver.SwitchTo().Window(windowHandle);



                    // Set up a fluent wait to handle possible delays and exceptions while interacting with elements

                    DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driverHelper.Driver);

                    fluentWait.Timeout = TimeSpan.FromSeconds(60);

                    fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
                    fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
                    fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(pPage.loginLabel)));



                    // Validate that certain conditions on the page are met

                    Assert.Multiple(() =>
                    {
                        Assert.That(pPage.confirmWelcomeMessageScreen, Is.True);

                        Assert.That(pPage.confirmLogin, Is.True);

                    });
                    // Close the new browser tab
                    _driverHelper.Driver.Close();
                    break;
                }
            }
            // Switch the WebDriver context back to the original browser window
            _driverHelper.Driver.SwitchTo().Window(mainWindowHandle);








        }








        
        

       


       
    }
}
