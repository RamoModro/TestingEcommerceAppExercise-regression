using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

namespace TestingEcommerceAppExercise.Pages
{
    public class Homepage : BasePage
    {
        #region Selectors

        private readonly By _createAccountLink = By.XPath("//a[text()='Create an Account']");

        private readonly By _searchInput = By.CssSelector("#search");
        private readonly By _searchButton = By.CssSelector(".action.search");

        private readonly By _items = By.CssSelector(".item.product");

        private readonly By _sortByDropDown = By.CssSelector("#sorter");
        private readonly By _productsPrices = By.CssSelector(".price");

        #endregion

        public void GoToCreateAccount() => _createAccountLink.ActionClick();

        public bool IsCreateAccountLinkDisplayed() => _createAccountLink.IsElementPresent();
      
        public void SearchItemByName(string keyword)
        {
            _searchInput.ActionSendKeys(keyword);
            _searchButton.ActionClick();
        }

        public bool IsSearchButtonEnabled() => _searchButton.IsElementEnabled();

        public bool IsProductInResults(string searchedItem)
        {
                var itemDetails = _items.GetElements();
            return itemDetails[0].Text.Contains(searchedItem);            
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
      
    }
}
