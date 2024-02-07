using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

namespace TestingEcommerceAppExercise.Pages;

public class ProductPage : BasePage
{
    #region Selector

    private readonly By _addToCartButton = By.CssSelector("#product-addtocart-button");

    private readonly By _sizeOptions = By.CssSelector(".swatch-option.text");
    private readonly By _colorOptions = By.CssSelector(".swatch-option.color");
    private readonly By _successMessage = By.CssSelector(".message-success");
    private readonly By _notAvailableMessage = By.CssSelector(".message-error");
    private readonly By _pageTitle = By.CssSelector(".page-title");

    private readonly By _shoppingCartLink = By.XPath("//a[text()='shopping cart']");

    #endregion

    public void ClickAddToCart()
    {
        _addToCartButton.ActionClick();
    }

    public void AddProductToCart()
    {
        if(!AreProductDetailsOptionsPresent()) return;
            _sizeOptions.GetElements().First().Click();
            _colorOptions.GetElements().First().Click();
        ClickAddToCart();
    }

    public bool IsSuccessMessageDisplayed()
    {
        if (!IsUnavailableMessagePresent());
        {
            _successMessage.WaitForElement();
            var productName = _pageTitle.GetText();
            return _successMessage.GetText().Contains("You added") &&
                    _successMessage.GetText().Contains(productName) &&
                    _successMessage.GetText().Contains("to your shopping cart");
        }
    }

    public void GoToCart()
    {
        WaitHelpers.ExplicitWait();
        _shoppingCartLink.ActionClick();
    }

    public bool AreProductDetailsOptionsPresent() => _sizeOptions.IsElementPresent()
        || _colorOptions.IsElementPresent();

    public bool IsUnavailableMessagePresent() => _notAvailableMessage.IsElementPresent();
}
