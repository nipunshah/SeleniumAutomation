// --------------------------------------------------------------------------------------------------------------------
// <copyright company="SomeCompany" file="AccountPage.cs">
//   Copyright 2015
// </copyright>
// <summary>
//   Page Object for accounts page and various actions on the same
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WebAutomation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    class AccountPage
    {
        private readonly string _homePage = @"http://store.demoqa.com/";
        private readonly string _accountLink = "//*[@id='account']/a";

        private readonly string _loginName = "//*[@id='log']";
        private readonly string _loginNameValue = "nipun";
        private readonly string _loginPassword = "//*[@id='pwd']";
        private readonly string _loginPasswordValue = "asdf1234";
        private readonly string _loginButton = "//*[@id='login']";

        private readonly string _scopeBarLink = "//*[@id='wp-admin-bar-my-account']/a";
        private readonly string _editProfileLink = "//*[@id='wp-admin-bar-edit-profile']/a";
        private readonly string _logoutLink = "//*[@id='wp-admin-bar-logout']/a";
        
        private readonly string _websiteInfo = "//*[@id='url']";
        private readonly string _websiteNewValue = "-" + DateTime.Now.Ticks;
        private readonly string _updateLink = "//*[@id='submit']";

        private readonly IWebDriver accountHome;
        
        // Initialize accounts page
        public AccountPage(IWebDriver driver)
        {
            accountHome = driver;            
        }

        // Login to the system
        public void Login()
        {
            accountHome.Navigate().GoToUrl(_homePage);
            var accountLink = accountHome.FindElement(By.XPath(_accountLink));
            accountLink.Click();

            var loginName = accountHome.FindElement(By.XPath(_loginName));
            loginName.SendKeys(_loginNameValue);

            var loginPassword = accountHome.FindElement(By.XPath(_loginPassword));
            loginPassword.SendKeys(_loginPasswordValue);

            var loginButton = accountHome.FindElement(By.XPath(_loginButton));
            loginButton.Click();
        }

        // Get profile information
        public string GetProfileInfo()
        {
            var menuElement = accountHome.FindElement(By.XPath(_scopeBarLink));
            bool isMenuVisible = menuElement.Displayed;
            if (!isMenuVisible) 
            {
                return string.Empty;
            }
            
            Actions builder = new Actions(accountHome);
            builder.MoveToElement(menuElement).Build().Perform();
            Thread.Sleep(2000);
            var editProfileLink = accountHome.FindElement(By.XPath(_editProfileLink));
            editProfileLink.Click();

            var websiteInfo = accountHome.FindElement(By.XPath(_websiteInfo));
            return websiteInfo.GetAttribute("value");
        }

        // Change profile information
        public void ChangeProfileInfo()
        {
            var websiteInfo = accountHome.FindElement(By.XPath(_websiteInfo));
            websiteInfo.SendKeys(_websiteNewValue);
            var updateProfile = accountHome.FindElement(By.XPath(_updateLink));
            updateProfile.Click();
        }

        // Logout of the system
        public void LogOut()
        {
            var menuElement = accountHome.FindElement(By.XPath(_scopeBarLink));
            bool isMenuVisible = menuElement.Displayed;
            if (!isMenuVisible)
            {
                return;
            }

            //accountHome.Navigate().GoToUrl("http://store.demoqa.com/tools-qa/?action=logout&_wpnonce=59fede0753");
            Actions builder = new Actions(accountHome);
            builder.MoveToElement(menuElement).Build().Perform();
            Thread.Sleep(4000);
            var logoutLink = accountHome.FindElement(By.XPath(_logoutLink));
            logoutLink.Click();
        }
    }
}
