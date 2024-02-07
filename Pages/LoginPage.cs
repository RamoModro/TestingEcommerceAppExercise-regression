using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

namespace TestingEcommerceAppExercise.Pages;

public class LoginPage : BasePage
{
    #region Selectors

    private readonly By _emailInput = By.CssSelector("#email");
    private readonly By _passwordInput = By.CssSelector("#pass");
    private readonly By _signInButton = By.CssSelector(".primary[type*='submit']");

    private readonly By _invalidSignInErrorMessage = By.CssSelector(".message-error");

    #endregion

    public void ClickSignIn() => _signInButton.ActionClick();

    public void DoLogin(string email, string password)
    {
        _emailInput.ActionSendKeys(email);
        _passwordInput.ActionSendKeys(password);
        ClickSignIn();
    }

    public bool IsInvalidAccountErrorMessageDisplayed()
    {
        _invalidSignInErrorMessage.WaitForElement();
       return _invalidSignInErrorMessage.GetText().Equals("The account sign-in was incorrect or your account is disabled temporarily. Please wait and try again later.");
    }
}
