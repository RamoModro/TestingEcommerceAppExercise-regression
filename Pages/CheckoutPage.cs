using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

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

        private readonly By _inputsErrorMessages = By.CssSelector(".field-error");
        private readonly By _emailInputErrorMessage = By.CssSelector("#customer-email-error");
        private readonly By _shippingMethodsErrorMessage = By.CssSelector(".message.notice");

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
        }

        public List<string> GetErrorMessages() => _inputsErrorMessages.GetElements().Select(x => x.Text).ToList();

        public string GetEmailErrorMessage() => _emailInputErrorMessage.GetText();

        public string GetShippingMethodsErrorMessage() => _shippingMethodsErrorMessage.GetText();
        
        public bool AreMandatoryErrorMessagesDisplayed()
        {
            var errorMessages = GetErrorMessages();
            return errorMessages.Count.Equals(7) && errorMessages.All(x => x.Contains("required field."));
        }

        public void SelectShippingMethod() => _shippingMethodButtons.GetElements().First().Click();

       //ublic void InsertShippingDetails() => 
    }
}
