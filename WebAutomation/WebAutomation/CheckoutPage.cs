// --------------------------------------------------------------------------------------------------------------------
// <copyright company="SomeCompany" file="AccountPage.cs">
//   Copyright 2015
// </copyright>
// <summary>
//   Page Object for checkout page and various actions on the same
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebAutomation
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;

    class CheckoutPage
    {        
        private readonly string _removeLink = "//*[@class='adjustform remove']/input[4]";
        private readonly string _continueLink = "//*[@id='checkout_page_container']/div[1]/a";
        private readonly string _emptyCart = "//*[@id='post-29']/div";
        private readonly string _emptyCartMessage = "Oops, there is nothing in your cart.";

        private readonly string _shippingDropdown = "//*[@id='current_country']";
        private readonly string _calculateShipping = "//*[@id='change_country']/input[4]";

        private readonly string _firstName = "//*[@id='wpsc_checkout_form_2']";
        private readonly string _firstNameValue = "Nipun";
        private readonly string _lastName = "//*[@id='wpsc_checkout_form_3']";
        private readonly string _lastNameValue = "Shah";
        private readonly string _address = "//*[@id='wpsc_checkout_form_4']";
        private readonly string _addressValue = "My residence";
        private readonly string _city = "//*[@id='wpsc_checkout_form_5']";
        private readonly string _cityValue = "Kirkland";
        private readonly string _state = "//*[@id='wpsc_checkout_form_6']";
        private readonly string _stateValue = "WA";
        private readonly string _country = "//*[@id='wpsc_checkout_form_7']";
        private readonly string _countryValue = "USA";
        private readonly string _phoneNum = "//*[@id='wpsc_checkout_form_18']";
        private readonly string _phoneNumValue = "123-456-7890";

        private readonly string _finalPrice = "//*[@id='checkout_total']/span";
        private readonly string _finalPriceValue = "$282.00";
        private readonly IWebDriver checkoutHome;

        // Initialize checkout page
        public CheckoutPage(IWebDriver driver)
        {
            checkoutHome = driver;
            
        }

        // Remove all items from cart
        public bool RemoveFromCart()
        {
            var removeLink = checkoutHome.FindElement(By.XPath(_removeLink));                
            var isRemovePresent = removeLink.Enabled;
            if (isRemovePresent)
            {
                removeLink.Click();
                var emptyCart = checkoutHome.FindElement(By.XPath(_emptyCart));
                var emptyCartMessage = emptyCart.Text;
                if (emptyCartMessage != _emptyCartMessage)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        // Continue shopping to fill details
        public bool ContinueShopping()
        {
            var continueLink = checkoutHome.FindElement(By.XPath(_continueLink));
            Thread.Sleep(3000);
            var isContinuePresent = continueLink.Enabled;
            if (isContinuePresent)
            {
                continueLink.Click();                
            }            
            return true;
        }

        // Fill in order details
        public void FillInOrderDetails()
        {            
            var shippingCountry = checkoutHome.FindElement(By.XPath(_shippingDropdown));
            shippingCountry.SendKeys(_countryValue);
            var calculateShipping = checkoutHome.FindElement(By.XPath(_calculateShipping));
            calculateShipping.Click();
            Thread.Sleep(3000);
            checkoutHome.FindElement(By.XPath("//*[@id='current_country']/option[233]")).Click();
            Thread.Sleep(3000);
            var firstName = checkoutHome.FindElement(By.XPath(_firstName));
            firstName.SendKeys(_firstNameValue);
            var lastName = checkoutHome.FindElement(By.XPath(_lastName));
            lastName.SendKeys(_lastNameValue);
            var addressField = checkoutHome.FindElement(By.XPath(_address));
            addressField.SendKeys(_addressValue);
            var cityField = checkoutHome.FindElement(By.XPath(_city));
            cityField.SendKeys(_cityValue);
            var stateField = checkoutHome.FindElement(By.XPath(_state));
            stateField.SendKeys(_stateValue);
            var countryField = checkoutHome.FindElement(By.XPath(_country));
            countryField.SendKeys(_countryValue);
            var phoneField = checkoutHome.FindElement(By.XPath(_phoneNum));
            phoneField.SendKeys(_phoneNumValue);            
        }

        // Verify checkout price
        public bool VerifyCheckoutPrice()
        {
            var finalPrice = checkoutHome.FindElement(By.XPath(_finalPrice));
            if (finalPrice.Text != _finalPriceValue)
            {
                return false;
            }
            return true;
        }
    }
}
