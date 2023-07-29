using OpenQA.Selenium;
using ZenithWeb.Drivers;
using OpenQA.Selenium.Interactions;


namespace ZenithWeb.Pages
{
    internal class PersonalPage
    {
        private readonly IWebDriver Driver;

        public PersonalPage(IWebDriver driver)
        {

            Driver = driver;
        }
        // XPath to find the Internet Banking menu item in the main navigation

        public string internetBmenu = "//nav[@id='main-navigation']//descendant::span[contains(text(),'INTERNET BANKING')]";
        // XPath to find the Personal menu item in the main navigation

        public string Personalmenu = "//nav[@id='main-navigation']//descendant::a[contains(text(),'PERSONAL')]";
        // XPath to find the Login label

        public string loginLabel = "//strong[contains(text(),'Login')]";
        // XPath to find the Welcome message displayed when user lands on the Internet Banking page

        public string welcomeLogin = "//h4[contains(text(),'Welcome to Zenith Bank Internet Banking')]";
        // IWebElement that represents the Internet Banking menu item

        public IWebElement internetBankingMenu => Driver.FindElement(By.XPath(internetBmenu));
        // IWebElement that represents the Personal menu item

        public IWebElement PersonalMenu=>Driver.FindElement(By.XPath(Personalmenu));
        // IWebElement that represents the Login label

        public IWebElement LoginLabel => Driver.FindElement(By.XPath(loginLabel));
        // IWebElement that represents the Welcome message

        public IWebElement WelcomeLogin => Driver.FindElement(By.XPath(welcomeLogin));


        // This method hovers over the specified web element
        public void Hover(IWebElement element)
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(element).Perform();
        }

        // This method first hovers over the specified web element and then clicks on another specified web element

        public void HoverAndClick(IWebElement elementToHover, IWebElement elementToClick)
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(elementToHover).Click(elementToClick).Build().Perform();
        }

        // This method checks if the Personal Menu element is displayed on the webpage
        public bool confirmPersonalMenuExist() => PersonalMenu.Displayed;
        // This method checks if the Login Label element is displayed on the webpage

        public bool confirmLogin() => LoginLabel.Displayed;
        // This method checks if the Welcome Message Screen element is displayed on the webpage

        public bool confirmWelcomeMessageScreen() => WelcomeLogin.Displayed;

    }
}
