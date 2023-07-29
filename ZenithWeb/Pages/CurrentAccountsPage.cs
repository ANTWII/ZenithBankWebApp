using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace ZenithWeb.Pages
{
    internal class CurrentAccountsPage
    {


        private readonly IWebDriver Driver;

        public CurrentAccountsPage(IWebDriver driver)
        {

            Driver = driver;
        }
        // XPath to find the 'Personal' menu item in the main navigation
        public string Personalmenu = "//nav[@id='main-navigation']//child::span[contains(text(),'Personal')]";
        // XPath to find the 'Individual Current Account' feature 

        public string indCurrentAcc_feature = "//h1[contains(text(),'Individual Current Account')]//parent::div//following::div[1]//child::a[contains(@id,'#features-and-benefits')]";
        // XPath to find the 'Individual Current Account' requirement 

        public string indCurrentAcc_requirement = "//h1[contains(text(),'Individual Current Account')]//parent::div//following::div[1]//child::a[contains(@id,'#requirements')]";
        // XPath to find the 'Individual Current Account' available channels 

        public string indCurrentAcc_channel = "//h1[contains(text(),'Individual Current Account')]//parent::div//following::div[1]//child::a[contains(@id,'#available-channels')]";
        // XPath to find the 'Current Account' label 
        public string currentaccountLabel = "//div[@id='main-container']//child::h2[contains(text(),'Current Account')]";
        // IWebElement that represents the 'Individual Current Account' feature

        public IWebElement IndCurrentAcc_Feature => Driver.FindElement(By.XPath(indCurrentAcc_feature));
        // IWebElement that represents the 'Individual Current Account' requirement

        public IWebElement IndCurrentAcc_Requirement => Driver.FindElement(By.XPath(indCurrentAcc_requirement));
        // IWebElement that represents the 'Individual Current Account' available channels

        public IWebElement IndCurrentAcc_Channel => Driver.FindElement(By.XPath(indCurrentAcc_channel));
        // IWebElement that represents the 'Personal' menu item

        public IWebElement PersonalMenu => Driver.FindElement(By.XPath(Personalmenu));
        // IWebElement that represents the 'Current Account' menu item in the main menu

        public IWebElement CurrentAccount => Driver.FindElement(By.XPath(" //ul[@id='menu-main-menu-1']/li[2]//child::a[contains(text(),'Current Account')]"));
        // IWebElement that represents the 'Current Account' label

        public IWebElement CurrentAccountLabel => Driver.FindElement(By.XPath(currentaccountLabel));


        // IList<IWebElement> that represents the list of 'Individual Current Account' features
        public IList<IWebElement> FeatureList => Driver.FindElements(By.XPath("//h1[contains(text(),'Individual Current Account')]//parent::div//following::div[1]//child::a[contains(@id,'#features-and-benefits')]//following::ul[1]/li"));
        // IList<IWebElement> that represents the list of 'Individual Current Account' requirements

        public IList<IWebElement> RequirementList => Driver.FindElements(By.XPath("//h1[contains(text(),'Individual Current Account')]//parent::div//following::div[1]//child::a[contains(@id,'#requirements')]//following::ul[1]/li"));
        // IList<IWebElement> that represents the list of 'Individual Current Account' available channels

        public IList<IWebElement> ChannelList => Driver.FindElements(By.XPath("//h1[contains(text(),'Individual Current Account')]//parent::div//following::div[1]//child::a[contains(@id,'#available-channels')]//following::ul[1]/li"));


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

        // This method retrieves and validates data from a list of web elements

        public List<string> ValidateListData(IList<IWebElement> List)
        {
            int listCount = List.Count();
            List<string> listdData = new List<string>();
            int countData = 0;


            foreach (IWebElement list in List)
            {

                
                    if (countData++ <= listCount)
                    {
                        if (!string.IsNullOrEmpty(list.Text))
                        {

                        listdData.Add(list.Text);


                        }


                    }

                
            }
            return listdData;
        }


        // This method checks if the Current Account Menu element is displayed on the webpage
        public bool confirmCurrentAccountMenu() => CurrentAccount.Displayed;
        // This method checks if the Current Account Label element is displayed on the webpage

        public bool confirmCurrentAccountPage() => CurrentAccountLabel.Displayed;
    }
}
