using OpenQA.Selenium;

namespace ZenithWeb.Pages
{
    internal class LandingPage
    {
        private readonly IWebDriver Driver;

        public LandingPage(IWebDriver driver)
        {

            Driver = driver;
        }
        // XPath to find the 'Home' banner in the header's sticky wrapper

        public string HomeBanner = "//div[@id='header-sticky-wrapper']";
        // IWebElement that represents the 'Home' banner

        public IWebElement homeBanner => Driver.FindElement(By.XPath(HomeBanner));
        // This method checks if the Home Banner element is displayed on the webpage

        public bool confirmHomePageExist() => homeBanner.Displayed;
    }
}
