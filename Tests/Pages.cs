using NsTestFrameworkUI.Pages;
using TestingEcommerceAppExercise.Pages;

namespace TestingEcommerceAppExercise.Tests;

public static class Pages
{
    public static Homepage Homepage = PageHelpers.InitPage(new Homepage());
    public static CreateAccountPage CreateAccountPage = PageHelpers.InitPage(new CreateAccountPage());
    public static ProductPage ProductPage = PageHelpers.InitPage(new ProductPage());
    public static CartPage CartPage = PageHelpers.InitPage(new CartPage());
    public static CheckoutPage CheckoutPage = PageHelpers.InitPage(new CheckoutPage());
    public static LoginPage LoginPage = PageHelpers.InitPage(new LoginPage());
}
