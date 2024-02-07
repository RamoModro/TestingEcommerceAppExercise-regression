using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkUI.Helpers;
using System.Runtime.ConstrainedExecution;
using TestingEcommerceAppExercise.Helpers;

namespace TestingEcommerceAppExercise.Tests;

[TestClass]
public class CartTests : BaseTest
{
    [TestInitialize]
    public override void Before()
    {
        base.Before();
    }

    [TestMethod]
    public void AddItemToCartTest()
    {
        Browser.GoTo(Constants.Url);

        Pages.Homepage.Search("Jacket");
        Pages.Homepage.OpenProduct("Jacket");

        Pages.ProductPage.AddProductToCart();
        Pages.ProductPage.IsSuccessMessageDisplayed().Should().BeTrue();
        Pages.ProductPage.GoToCart();

        Pages.CartPage.GetPageTitle().Should().Be("Shopping Cart");
        Pages.CartPage.IsProductInCart("Jacket").Should().BeTrue();
    }

    [TestMethod]
    public void ModifyItemQuantityInCartTest()
    {
        Browser.GoTo(Constants.Url);

        Pages.Homepage.Search("Jacket");
        Pages.Homepage.OpenProduct("Jacket");

        Pages.ProductPage.AddProductToCart();
        Pages.ProductPage.GoToCart();

        Pages.CartPage.ChangeProductQuantity("3");
        Pages.CartPage.IsQuantityUpdated("3").Should().BeTrue();
    }

    [TestMethod]
    public void ItemSubtotalIsUpdatedTest()
    {
        Browser.GoTo(Constants.Url);

        Pages.Homepage.Search("Top");
        Pages.Homepage.OpenProduct("Top");

        Pages.ProductPage.AddProductToCart();
        Pages.ProductPage.GoToCart();

        Pages.CartPage.ChangeProductQuantity("5");
        Pages.CartPage.IsProductSubtotalCorrectlyUpdated().Should().BeTrue();
    }

    [TestMethod]
    public void ItemCanBeRemovedFromCartTest()
    {
        Browser.GoTo(Constants.Url);

        Pages.Homepage.Search("Top");
        Pages.Homepage.OpenProduct("Top");
        Pages.ProductPage.AddProductToCart();

        Pages.Homepage.Search("Pant");
        Pages.Homepage.OpenProduct("Pant");
        Pages.ProductPage.AddProductToCart();

        Pages.ProductPage.GoToCart();
        Pages.CartPage.RemoveFirstItemFromCart();
        Pages.CartPage.IsProductInCart("Top").Should().BeFalse();
    }

    [TestMethod]
    public void CheckoutPageIsDisplayedTest()
    {
        Browser.GoTo(Constants.Url);

        Pages.Homepage.Search("Jacket");
        Pages.Homepage.OpenProduct("Jacket");

        Pages.ProductPage.AddProductToCart();
        Pages.ProductPage.GoToCart();

        Pages.CartPage.ClickCheckout();
        Pages.CheckoutPage.IsCheckoutPageDisplayed().Should().BeTrue();
    }

    [TestMethod]

    public void ShippingRateCanBeAddedToOrderTest()
    {
        Browser.GoTo(Constants.Url);

        Pages.Homepage.Search("Jacket");
        Pages.Homepage.OpenProduct("Jacket");

        Pages.ProductPage.AddProductToCart();
        Pages.ProductPage.GoToCart();

        Pages.CartPage.AddShippingRate();
        Pages.CartPage.IsShippingRateAddedToOrder();
    }

    [TestCleanup]
    public override void After()
    {
        base.After();
    }
}
