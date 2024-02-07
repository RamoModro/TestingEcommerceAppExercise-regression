using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkUI.Helpers;
using TestingEcommerceAppExercise.Helpers;

namespace TestingEcommerceAppExercise.Tests;

[TestClass]
public class CheckoutTests : BaseTest
{
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
        Pages.CartPage.ClickCheckout();

        Pages.CheckoutPage.ClickNext();
        Pages.CheckoutPage.GetShippingMethodsErrorMessage().Should().Be("The shipping method is missing. Select the shipping method and try again.");
        Pages.CheckoutPage.SelectShippingMethod();
        Pages.CheckoutPage.ClickNext();
        Pages.CheckoutPage.GetEmailErrorMessage().Should().Be(Constants.RequiredErrorMessage);
        Pages.CheckoutPage.AreMandatoryErrorMessagesDisplayed().Should().BeTrue();
    }


    [TestCleanup]
    public override void After()
    {
        base.After();
    }
}
