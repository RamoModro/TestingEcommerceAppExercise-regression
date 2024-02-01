using NsTestFrameworkUI.Pages;
using TestingEcommerceAppExercise.Pages;

namespace TestingEcommerceAppExercise.Tests;

public static class Pages
{
    public static Homepage Homepage = PageHelpers.InitPage(new Homepage());
    public static CreateCustomerAccountPage CreateNewAccountPage = PageHelpers.InitPage(new CreateCustomerAccountPage());
}
