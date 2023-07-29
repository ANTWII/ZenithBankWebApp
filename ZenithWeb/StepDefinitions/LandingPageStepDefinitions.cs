using NUnit.Framework;
using OpenQA.Selenium;
using ZenithWeb.Pages;
using ZenithWeb.Drivers;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace ZenithWeb.StepDefinitions
{
    [Binding]
    public class LandingPageStepDefinitions
    {
        LandingPage lpage;
        private DriverHelper _driverHelper;
        private readonly ScenarioContext _scenarioContext;
        public LandingPageStepDefinitions(DriverHelper driverHelper, ScenarioContext scenarioContext)
        {
            _driverHelper = driverHelper;
            lpage=new LandingPage(_driverHelper.Driver);
            _scenarioContext = scenarioContext;
        }

        [Given(@"I am a new user accessing the Zenith Bank website")]
        public void GivenIAmANewUserAccessingTheZenithBankWebsite()
        {

            _scenarioContext["URL"] = "https://www.zenithbank.com";
        }

        [When(@"I load the Zenith Bank landing page")]
        public void WhenILoadTheZenithBankLandingPage()
        {

            dynamic url = _scenarioContext["URL"];
            _driverHelper.Driver.Navigate().GoToUrl(url);


            

        }

        [Then(@"the URL should display the zenith homepage url")]
        public void ThenTheURLShouldDisplayTheZenithHomepageUrl()
        {
            dynamic url = _scenarioContext["URL"];
            string currentUrl = _driverHelper.Driver.Url;

            //Wait till url contains the zenith web url
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driverHelper.Driver);

            fluentWait.Timeout = TimeSpan.FromSeconds(60);

            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            fluentWait.Until(ExpectedConditions.UrlContains(_driverHelper.Driver.Url = url));


            //Assertion

            Assert.IsTrue(currentUrl.Contains(url));
        }

       

        [Then(@"I should see the Zenith Bank banner on the page")]
        public void ThenIShouldSeeTheZenithBankBannerOnThePage()
        {
            //Wait till home page banner loads
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driverHelper.Driver);

            fluentWait.Timeout = TimeSpan.FromSeconds(60);

            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            fluentWait.Until(ExpectedConditions.ElementExists(By.XPath(lpage.HomeBanner)));

            //Assertion
            Assert.That(lpage.confirmHomePageExist());

        }
    }
}
