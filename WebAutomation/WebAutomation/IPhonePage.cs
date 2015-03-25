// --------------------------------------------------------------------------------------------------------------------
// <copyright company="SomeCompany" file="AccountPage.cs">
//   Copyright 2015
// </copyright>
// <summary>
//   Page Object for iphone page and various actions on the same
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebAutomation
{
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class IPhonePage
    {
        private readonly string _iPhoneContainer = "//*[@id='default_products_page_container']";
        private readonly string _iPhone4S16GBlack = "/div[4]";
        private readonly string _addToCartLink = "/div[2]/form/div[2]/div[1]/span/input";
        private readonly string _confirmAdd = "//*[@id='fancy_notification_content']/a[1]";
        
        private readonly IWebDriver iPhoneHome;

        // Initialize iPhone page
        public IPhonePage(IWebDriver driver)
        {
            iPhoneHome = driver;            
        }

        // Add iPhone 4S 16BG Black model to cart
        public bool ClickOnIPhone4S16GBlackCartLink() 
        {
            var iPhoneContainer = iPhoneHome.FindElement(By.XPath(_iPhoneContainer));
            bool isVisible = iPhoneContainer.Displayed;
            if (isVisible)
            {
                var iPhoneCartLink = _iPhoneContainer + _iPhone4S16GBlack + _addToCartLink;
                var iPhoneCartElement = iPhoneHome.FindElement(By.XPath(iPhoneCartLink));                
                iPhoneHome.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(4));
                bool isCartLink = iPhoneCartElement.Displayed;
                if (isCartLink)
                {
                    iPhoneCartElement.Click();
                    var confirmationDialog = iPhoneHome.FindElement(By.XPath(_confirmAdd));
                    bool isConfirmationVisible = confirmationDialog.Displayed;
                    if (isConfirmationVisible)
                    {
                        confirmationDialog.Click();
                    }
                }
            }
            return isVisible;
        }       
    }
}
