using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

namespace TestingEcommerceAppExercise.Pages;

public class CartPage : BasePage
{
    #region Selectors

    private readonly By _productNames = By.CssSelector(".cart.item .product-item-name");
    private readonly By _quantityInput = By.CssSelector(".input-text.qty");

    private readonly By _updateCartButton = By.CssSelector(".action.update");

    private readonly By _productsSubtotals = By.CssSelector(".col.subtotal .price");
    private readonly By _firstProductPrice = By.CssSelector(".col.price .price-excluding-tax");
    private readonly By _orderTotal = By.CssSelector(".grand.totals .price");
    private readonly By _orderSubtotal = By.CssSelector(".totals.sub .amount");
    private readonly By _appliedShippingRate = By.CssSelector(".totals.shipping.excl .amount");

    private readonly By _removeItemButtons = By.CssSelector(".action-delete");
    private readonly By _checkoutButton = By.CssSelector(".item .action.primary.checkout");

    private readonly By _shippingAndTaxExpand = By.CssSelector("#block-shipping-heading");
    private readonly By _flatShippingRate = By.XPath("//label[text()='Fixed']");

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
        _updateCartButton.ActionClick();
        WaitHelpers.ExplicitWait();
    }

    public bool IsQuantityUpdated(string newQuantity) => _quantityInput.GetAttribute("value").Equals(newQuantity);

    private int GetFirstProductPrice() => GetIntFromPrice(_firstProductPrice.GetText());

    public int GetProductsSubtotals() => GetIntFromPrice(_productsSubtotals.GetElements().First().Text.ToString());

    private int GetProductQuantity() => int.Parse(_quantityInput.GetAttribute("value").ToString());

    public bool IsProductSubtotalCorrectlyUpdated() => GetProductsSubtotals() == (GetFirstProductPrice() * GetProductQuantity());

    public void RemoveFirstItemFromCart() => _removeItemButtons.GetElements().First().Click();

    public void ClickCheckout() => _checkoutButton.ActionClick();

    public void AddShippingRate()
    {
        _shippingAndTaxExpand.ActionClick();
        _flatShippingRate.ActionClick();
    }

    private int GetOrderTotal() => GetIntFromPrice(_orderTotal.GetText());   

    private int GetOrderSubtotal() => GetIntFromPrice(_orderSubtotal.GetText());

    private int GetAppliedShippingRate() => GetIntFromPrice(_appliedShippingRate.GetText());

    public bool IsShippingRateAddedToOrder()
    {
        return GetOrderTotal() == GetOrderSubtotal() + GetAppliedShippingRate();
    }
}
