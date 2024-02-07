using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkUI.Helpers;
using TestingEcommerceAppExercise.Helpers;
using TestingEcommerceAppExercise.Helpers.Models;

namespace TestingEcommerceAppExercise.Tests;

[TestClass]
public class CheckoutTests : BaseTest
{
    private readonly ShippingDetails _shippingDetails = new();


    [TestInitialize]
    public override void Before()
    {
        base.Before();
    }

    [TestMethod]
    public void CheckErrorMessagesAtCheckoutTest()
    {
        Browser.GoTo(Constants.Url);

        Pages.Homepage.Search("Jacket");
        Pages.Homepage.OpenProduct("Jacket");

        Pages.ProductPage.AddProductToCart();
        Pages.ProductPage.GoToCart();
        Pages.CartPage.GoToCheckout();

        Pages.CheckoutPage.ClickNext();
        Pages.CheckoutPage.IsShippingErrorMessageDisplayed().Should().BeTrue();
        Pages.CheckoutPage.SelectShippingMethod();
        Pages.CheckoutPage.ClickNext();
        Pages.CheckoutPage.GetEmailErrorMessage().Should().Be(Constants.RequiredErrorMessage);
        Pages.CheckoutPage.AreMandatoryErrorMessagesDisplayed().Should().BeTrue();
    }

    [TestMethod]
    public void CheckoutAsAGuestTest()
    {
        Browser.GoTo(Constants.Url);

        Pages.Homepage.Search("Jacket");
        Pages.Homepage.OpenProduct("Jacket");

        Pages.ProductPage.AddProductToCart();
        Pages.ProductPage.GoToCart();
        Pages.CartPage.GoToCheckout();

        Pages.CheckoutPage.InsertShippingDetails(_shippingDetails);
        Pages.CheckoutPage.PlaceOrder();
        Pages.CheckoutPage.IsOrderConfirmationSuccessMessageDisplayed().Should().BeTrue();
    }

    [TestMethod]
    public void CheckoutAsExistingCustomerTest()
    {
        Browser.GoTo(Constants.Url);

        Pages.Homepage.GoToLogin();
        Pages.LoginPage.DoLogin(Constants.UserEmail, Constants.UserPass);

        Pages.Homepage.Search("Jacket");
        Pages.Homepage.OpenProduct("Jacket");

        Pages.ProductPage.AddProductToCart();
        Pages.ProductPage.GoToCart();

        Pages.CartPage.GoToCheckout();
        Pages.CheckoutPage.ClickNext();
        Pages.CheckoutPage.PlaceOrder();
        Pages.CheckoutPage.IsOrderConfirmationSuccessMessageDisplayed().Should().BeTrue();
    }

    [TestCleanup]
    public override void After()
    {
        base.After();
    }
}
