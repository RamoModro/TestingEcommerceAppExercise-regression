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
    public void AddProductToCartTest()
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
    public void ModifyProductQuantityInCartTest()
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
    public void CheckProductCartSubtotalTest()
    {
        Browser.GoTo(Constants.Url);

        Pages.Homepage.Search("Top");
        Pages.Homepage.OpenProduct("Top");

        Pages.ProductPage.AddProductToCart();
        Pages.ProductPage.GoToCart();

        Pages.CartPage.ChangeProductQuantity("5");
    }

    //public void CheckErrorMessagesWhenAddingProductToCartTest()
    //{

    //}

    [TestCleanup]
    public override void After()
    {
        base.After();
    }
}
