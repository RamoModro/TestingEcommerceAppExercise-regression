using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

namespace TestingEcommerceAppExercise.Pages;

public class CartPage : BasePage
{
    #region Selectors

    private readonly By _productNames = By.CssSelector(".cart.item .product-item-name");
    private readonly By _quantityInput = By.CssSelector(".input-text.qty");
    private readonly By _updateShoppingCartButton = By.CssSelector(".action.update");

    private readonly By _productsSubtotalValues = By.CssSelector(".col.subtotal .price");
    private readonly By _firstProductPrice = By.CssSelector("");

    #endregion

    public bool IsProductInCart(string productName)
    {
        return _productNames.GetElements()
            .Any(name => name.Text.Contains(productName));
    }

    public void ChangeProductQuantity(string quantity)
    {
        _quantityInput.ActionSendKeys(quantity);
        UpdateShoppingCart();
    }
    
    public void UpdateShoppingCart()
    {
        _updateShoppingCartButton.ActionClick();
        WaitHelpers.ExplicitWait();
    }

    public bool IsQuantityUpdated(string newQuantity)
    {
         return _quantityInput.GetAttribute("value").Equals(newQuantity);
    }

    public 
}
