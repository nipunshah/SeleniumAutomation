namespace WebAutomation
{
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium.Interactions;

    class StoreHome
    {
        private readonly string _homePageLink = @"http://store.demoqa.com/";        
        private readonly string _menu = "//*[@id='menu-item-33']/a";
        private readonly string _menuIPhoneLink = "//*[@id='menu-item-37']/a";
        
        private readonly IWebDriver storeHome;
 
        // Initialize home page
        public StoreHome(IWebDriver driver)
        {
            storeHome = driver;
            storeHome.Navigate().GoToUrl(_homePageLink);                      
        }

        // Click on menu bar
        public bool ClickOnMenu() {
            var menuElement = storeHome.FindElement(By.XPath(_menu));
            bool isMenuVisible = menuElement.Displayed;
            if (isMenuVisible)
            {
                Actions builder = new Actions(storeHome);
                builder.MoveToElement(menuElement).Build().Perform();                
                storeHome.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(4));
            }
            return isMenuVisible;
        }
 
        // Go to iPhone page
        public void ClickonIPhoneLink(){
            var iPhoneLinkElement = storeHome.FindElement(By.XPath(_menuIPhoneLink));
            var isLinkVisible = iPhoneLinkElement.Displayed;
            if (isLinkVisible)
            {
                iPhoneLinkElement.Click();
            }
        }
    }
}
