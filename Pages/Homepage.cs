using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

namespace TestingEcommerceAppExercise.Pages
{
    public class Homepage : BasePage
    {
        #region Selectors

        private readonly By _createAccountLink = By.XPath("//a[text()='Create an Account']");
        private readonly By _signInLink = By.CssSelector("a[href*=\"login\"]");

        private readonly By _searchInput = By.CssSelector("#search");
        private readonly By _searchButton = By.CssSelector(".action.search");

        private readonly By _products = By.CssSelector(".products .item.product");

        private readonly By _sortByDropDown = By.CssSelector("#sorter");
        private readonly By _productsPrices = By.CssSelector(".price");

        #endregion

        public void GoToCreateAccount() => _createAccountLink.ActionClick();

        public void GoToLogin() => _signInLink.ActionClick();

        public bool IsCreateAccountLinkDisplayed() => _createAccountLink.IsElementPresent();

        public bool IsSignInLinkDisplayed() => _signInLink.IsElementPresent();

        public void Search(string searchInput)
        {
            _searchInput.ActionSendKeys(searchInput);
            _searchButton.ActionClick();
            WaitHelpers.ExplicitWait();
        }

        public bool IsSearchButtonEnabled() => _searchButton.IsElementEnabled();

        public bool IsProductInResults(string searchedItem)
        {
                var productDetails = _products.GetElements();
            return productDetails[0].Text.Contains(searchedItem);            
        }

        public void SelectSortByDropdownValue()
        {
            _sortByDropDown.SelectFromDropdownByText("Price");
        }

        public List<string> GetProductsPrices()
        {
            WaitHelpers.ExplicitWait();
            return _productsPrices.GetElements().Select(x=>x.Text).ToList();
        }

        public bool IsPriceDescending()
        {
            return GetIntFromPrice(GetProductsPrices()[0].ToString())
                >GetIntFromPrice(GetProductsPrices()[(GetProductsPrices().Count-1)].ToString());
        }

        public void OpenProduct(string itemName)
        {
            PageHelpers.ScrollDownToView(5);
           var productDetails = _products.GetElements();
            if (productDetails[0].Text.Contains(itemName))
            {
                productDetails.First().Click();
                WaitHelpers.ExplicitWait();
            }          
        }     
    }
}
