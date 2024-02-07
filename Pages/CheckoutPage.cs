using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using System;
using TestingEcommerceAppExercise.Helpers.Models;

namespace TestingEcommerceAppExercise.Pages
{
    public class CheckoutPage : BasePage
    {
        #region Selectors

        private readonly By _shippingAddressForm = By.CssSelector("#shipping");
        private readonly By _orderSummaryDetails = By.CssSelector(".opc-block-summary");
        private readonly By _shippingMethodsSelection = By.CssSelector("#opc-shipping_method");

        private readonly By _nextButton = By.CssSelector(".button");
        private readonly By _shippingMethodButtons = By.CssSelector(".radio");
        private readonly By _placeOrderButton = By.CssSelector("button[title*='Place Order'] span");

        private readonly By _inputsErrorMessages = By.CssSelector(".field-error");
        private readonly By _emailInputErrorMessage = By.CssSelector("#customer-email-error");
        private readonly By _shippingMethodsErrorMessage = By.CssSelector(".message.notice");
        private readonly By _orderConfirmationSuccessMessage = By.CssSelector(".page-title-wrapper");

        private readonly By _emailInput = By.CssSelector(".control._with-tooltip #customer-email.input-text");
        private readonly By _firstNameInput = By.CssSelector(".input-text[name*='firstname']");
        private readonly By _lastNameInput = By.CssSelector(".input-text[name*='lastname']");
        private readonly By _streetInput = By.CssSelector(".input-text[name*='street']");
        private readonly By _cityInput = By.CssSelector(".input-text[name*='city']");
        private readonly By _postcodeInput = By.CssSelector(".input-text[name*='postcode']");
        private readonly By _phoneInput = By.CssSelector(".input-text[name*='telephone']");

        private readonly By _countryDropdown = By.CssSelector(".select[name*='country']");
        private readonly By _stateDropdown = By.CssSelector(".select[name*='region']");      

        #endregion


        public bool IsCheckoutPageDisplayed()
        {
            _shippingAddressForm.WaitUntilElementIsVisible();
            return _orderSummaryDetails.IsElementPresent() &&
                   _shippingMethodsSelection.IsElementPresent();
        }

        public void ClickNext()
        {
            PageHelpers.ScrollDownToView(500);
            _nextButton.ActionClick();
            WaitHelpers.ExplicitWait();
        }

        public List<string> GetErrorMessages() => _inputsErrorMessages.GetElements().Select(x => x.Text).ToList();

        public string GetEmailErrorMessage() => _emailInputErrorMessage.GetText();

        public bool IsShippingErrorMessageDisplayed()
        {
            _shippingMethodsErrorMessage.WaitForElement();
            return _shippingMethodsErrorMessage.GetText().Equals("The shipping method is missing. Select the shipping method and try again.");
        }

        public bool AreMandatoryErrorMessagesDisplayed()
        {
            var errorMessages = GetErrorMessages();
            return errorMessages.Count.Equals(7) && errorMessages.All(x => x.Contains("required field."));
        }

        public void SelectShippingMethod() => _shippingMethodButtons.GetElements().First().Click();

        public void InsertShippingDetails(ShippingDetails details)
        {
            _emailInput.ActionSendKeys(details.Email);
            _firstNameInput.ActionSendKeys(details.FirstName);
            _lastNameInput.ActionSendKeys(details.LastName);
            _streetInput.ActionSendKeys(details.StreetAddress);

            SelectCountry(details.Country);
            SelectState(details.StateProvince);

            _cityInput.ActionSendKeys(details.City);
            _postcodeInput.ActionSendKeys(details.PostalCode);
            _phoneInput.ActionSendKeys(details.PhoneNumber);

            WaitHelpers.ExplicitWait();
            ClickNext();
        }

        private void SelectCountry(string country)
        {
            WaitHelpers.ExplicitWait();
            _countryDropdown.ActionClick();
            _countryDropdown.SelectFromDropdownByText(country);
        }

        private void SelectState(string state)
        {
            WaitHelpers.ExplicitWait();
            _stateDropdown.ActionClick();
            _stateDropdown.SelectFromDropdownByText(state);
        }

        public void PlaceOrder()
        {
            PageHelpers.ScrollDownToView(50);
            _placeOrderButton.ActionClick();
            WaitHelpers.ExplicitWait(3000);
        }

        public bool IsOrderConfirmationSuccessMessageDisplayed()
        {
            _orderConfirmationSuccessMessage.WaitUntilElementIsVisible();
            return _orderConfirmationSuccessMessage.GetText().Contains("Thank you for your purchase!");
        }
    }
}
