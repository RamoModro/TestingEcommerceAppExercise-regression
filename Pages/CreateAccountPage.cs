using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using TestingEcommerceAppExercise.Helpers.Models;

namespace TestingEcommerceAppExercise.Pages
{
    public class CreateAccountPage : BasePage
    {
        #region Selectors

        private readonly By _firstNameInput = By.CssSelector("#firstname");
        private readonly By _lastNameInput = By.CssSelector("#lastname");
        private readonly By _emailInput = By.CssSelector("#email_address");
        private readonly By _passwordInput = By.CssSelector("#password:first-child");
        private readonly By _passwordConfirmationInput = By.CssSelector("#password-confirmation");
        private readonly By _createAccountButton = By.CssSelector(".action.submit");

        private readonly By _successMessage = By.CssSelector(".message-success");

        #endregion

        public void SubmitDetails() => _createAccountButton.ActionClick();

        public void InsertUserDetails(Customer user)
        {
            _firstNameInput.ActionSendKeys(user.FirstName);
            _lastNameInput.ActionSendKeys(user.LastName);
            _emailInput.ActionSendKeys(user.Email);
            _passwordInput.ActionSendKeys(user.Password);
            _passwordConfirmationInput.ActionSendKeys(user.Password);

            SubmitDetails();
        }

        public bool IsSuccessMessageDisplayed()
        {
            _successMessage.WaitForElement();
            return _successMessage.GetText().Equals("Thank you for registering with Main Website Store.");
        }
    }
}
