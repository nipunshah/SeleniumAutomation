// --------------------------------------------------------------------------------------------------------------------
// <copyright company="SomeCompany" file="TestClass.cs">
//   Copyright 2015
// </copyright>
// <summary>
//   Test class containing all test cases along with setup and tear down of environment
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WebAutomation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Chrome;
    using NUnit.Framework;
    using System.Threading;
    
    [TestFixture] 
    class TestClass
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // TODO: Modify this path to point to right location
            driver = new ChromeDriver(@"C:\Users\nipuns\Documents\Visual Studio 2013\Projects\WebAutomation\Drivers");            
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }

        //
        // Test to buy an iPhone
        //
        [Test]
        public void BuyIPhone()
        {
            StoreHome sHome = new StoreHome(driver);
            bool isMenuOpen = sHome.ClickOnMenu();
            sHome.ClickonIPhoneLink();

            IPhonePage iPage = new IPhonePage(driver);
            iPage.ClickOnIPhone4S16GBlackCartLink();
                        
            CheckoutPage cPage = new CheckoutPage(driver);
            cPage.ContinueShopping();
            Thread.Sleep(2000);
            cPage.FillInOrderDetails();
            Thread.Sleep(3000);
            bool isCorrectPrice = cPage.VerifyCheckoutPrice();
            Assert.IsTrue(isCorrectPrice, "Could not verify the correct price on the checkout page");
        }

        //
        // Test to remove all items from cart
        //
        [Test]
        public void RemoveCartItem()
        {
            StoreHome sHome = new StoreHome(driver);
            bool isMenuOpen = sHome.ClickOnMenu();
            sHome.ClickonIPhoneLink();

            IPhonePage iPage = new IPhonePage(driver);
            iPage.ClickOnIPhone4S16GBlackCartLink();
            Thread.Sleep(2000);

            CheckoutPage cPage = new CheckoutPage(driver);
            bool bSuccess = cPage.RemoveFromCart();
            Assert.IsTrue(bSuccess, "Could not remove element from the cart");
        }

        //
        // Test to change account details
        //
        [Test]
        public void AccountDetails()
        {
            StoreHome sHome = new StoreHome(driver);
            AccountPage aPage = new AccountPage(driver);
            aPage.Login();
            Thread.Sleep(3000);
            var previousValue = aPage.GetProfileInfo();
            Thread.Sleep(3000);
            aPage.ChangeProfileInfo();
            Thread.Sleep(2000);
            aPage.LogOut();
            Thread.Sleep(3000);
            aPage.Login();
            Thread.Sleep(3000);
            var newValue = aPage.GetProfileInfo();
            Assert.AreNotEqual(previousValue, newValue, "Profile edit was not successful");     
        }
    }
}
