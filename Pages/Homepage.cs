using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

namespace TestingEcommerceAppExercise.Pages
{
    public class Homepage : BasePage
    {
        #region Selectors

        private readonly By _createAccountLink = By.XPath("//a[text()='Create an Account']");

        #endregion


        public void GoToCreateAccount() => _createAccountLink.ActionClick();

        public bool IsCreateAccountLinkDisplayed() => _createAccountLink.IsElementPresent();
      

    }


}
