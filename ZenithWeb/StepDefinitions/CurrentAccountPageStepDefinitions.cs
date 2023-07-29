using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;
using ZenithWeb.Drivers;
using ZenithWeb.Pages;
using static System.Net.Mime.MediaTypeNames;
using TechTalk.SpecFlow.Assist;
namespace ZenithWeb.StepDefinitions
{
    [Binding]
    public class CurrentAccountPageStepDefinitions
    {
        CurrentAccountsPage cPage;
        private DriverHelper _driverHelper;
        private readonly ScenarioContext _scenarioContext;
        public CurrentAccountPageStepDefinitions(DriverHelper driverHelper, ScenarioContext scenarioContext)
        {
            _driverHelper = driverHelper;
            cPage = new CurrentAccountsPage(_driverHelper.Driver);
            _scenarioContext = scenarioContext;
        }
        [Then(@"the Current account  menu should be displayed")]
        public void ThenTheCurrentAccountMenuShouldBeDisplayed()
        {
            WebDriverWait Wait = new WebDriverWait(_driverHelper.Driver, TimeSpan.FromSeconds(60));
            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(cPage.Personalmenu)));


            Assert.That(cPage.confirmCurrentAccountMenu, Is.True);
        }

        [When(@"I click on the Current account  menu")]
        public void WhenIClickOnTheCurrentAccountMenu()
        {
            cPage.CurrentAccount.Click();
        }

        [Then(@"I should be redirected to the Currdent account page")]
        public void ThenIShouldBeRedirectedToTheCurrdentAccountPage()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driverHelper.Driver);

            fluentWait.Timeout = TimeSpan.FromSeconds(60);

            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            fluentWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(cPage.currentaccountLabel)));

            Assert.That(cPage.confirmCurrentAccountPage, Is.True);
        }


        [When(@"Expand the features and benefits on individual current Account")]
        public void WhenExpandTheFeaturesAndBenefitsOnIndividualCurrentAccount()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driverHelper.Driver);

            fluentWait.Timeout = TimeSpan.FromSeconds(60);

            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(cPage.indCurrentAcc_feature)));

            cPage.IndCurrentAcc_Feature.Click();
        }

        [Then(@"i should  see the folliowing features and benefits")]
        public void ThenIShouldSeeTheFolliowingFeaturesAndBenefits(Table table)
        {
            List<string> ListData = cPage.ValidateListData(cPage.FeatureList);
            dynamic data = table.CreateDynamicSet();
        
            foreach (var  userData in data)
            {


                Assert.Contains(userData.Features_Benefits, ListData);

            }


        }

        [When(@"Expand the Requirements on individual current Account")]
        public void WhenExpandTheRequirementsOnIndividualCurrentAccount()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driverHelper.Driver);

            fluentWait.Timeout = TimeSpan.FromSeconds(60);

            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(cPage.indCurrentAcc_requirement)));

            cPage.IndCurrentAcc_Requirement.Click();
        }

        [Then(@"i should  see the folliowing Requirements")]
        public void ThenIShouldSeeTheFolliowingRequirements(Table table)
        {
            List<string> ListData = cPage.ValidateListData(cPage.RequirementList);
            dynamic data = table.CreateDynamicSet();

            foreach (var userData in data)
            {


                Assert.Contains(userData.Requirements, ListData);

            }
        }

        [When(@"Expand the Channels on individual current Account")]
        public void WhenExpandTheChannelsOnIndividualCurrentAccount()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driverHelper.Driver);

            fluentWait.Timeout = TimeSpan.FromSeconds(60);

            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(cPage.indCurrentAcc_channel)));

            cPage.IndCurrentAcc_Channel.Click();
        }
        

        [Then(@"i should  see the folliowing Channels")]
        public void ThenIShouldSeeTheFolliowingChannels(Table table)
        {
            List<string> ListData = cPage.ValidateListData(cPage.ChannelList);
            dynamic data = table.CreateDynamicSet();

            foreach (var userData in data)
            {


                Assert.Contains(userData.Channels, ListData);

            }
        }

    }
}
