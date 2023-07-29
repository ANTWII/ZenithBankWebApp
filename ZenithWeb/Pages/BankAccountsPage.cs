using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithWeb.Pages
{
    internal class BankAccountsPage
    {

        private readonly IWebDriver Driver;

        public BankAccountsPage(IWebDriver driver)
        {

            Driver = driver;
        }
        // XPath to find the 'Personal' menu item
        public string Personalmenu = "//nav[@id='main-navigation']//child::span[contains(text(),'Personal')]";
        // XPath to find the 'Bank Accounts' label
        public string bankaccountLabel = "//div[@id=\"main-container\"]//child::h2[contains(text(),'Bank Accounts')]";
        // IWebElement that represents the 'Personal' menu item

        public IWebElement PersonalMenu => Driver.FindElement(By.XPath(Personalmenu));
        // IWebElement that represents the 'Bank Accounts' menu item in the main menu

        public IWebElement BankAccount => Driver.FindElement(By.XPath(" //*[@id=\"menu-main-menu-1\"]/li[2]//child::a[contains(text(),'Bank Accounts')]"));
        // IWebElement that represents the 'Bank Accounts' label

        public IWebElement BankAccountLabel => Driver.FindElement(By.XPath(bankaccountLabel));

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


        // This method checks if the Bank Account Menu element is displayed on the webpage
        public bool confirmBankAccountMenu() => BankAccount.Displayed;
        // This method checks if the Bank Account Label element is displayed on the webpage

        public bool confirmBankAccountPage() => BankAccountLabel.Displayed;
    }
}
