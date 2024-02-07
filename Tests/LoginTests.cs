using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkUI.Helpers;
using TestingEcommerceAppExercise.Helpers;

namespace TestingEcommerceAppExercise.Tests;

[TestClass]
public class LoginTests : BaseTest
{
    [TestInitialize]
    public override void Before()
    {
        base.Before();
    }

    [TestMethod]
    public void LoginWithValidCredentialsTest()
    {
        Browser.GoTo(Constants.Url);

        Pages.Homepage.GoToLogin();
        Pages.LoginPage.InsertLoginDetails(Constants.UserEmail, Constants.UserPass);
        Pages.LoginPage.ClickSignIn();
        Pages.Homepage.IsSignInLinkDisplayed().Should().BeFalse();
    }

    [TestMethod]
    public void LoginWithInvalidCredentialsTest()
    {
        Browser.GoTo(Constants.Url);

        Pages.Homepage.GoToLogin();
        Pages.LoginPage.InsertLoginDetails("invalid@mail.com", Constants.UserPass);
        Pages.LoginPage.ClickSignIn();
        Pages.LoginPage.IsInvalidAccountErrorMessageDisplayed().Should().BeTrue();
        Pages.LoginPage.InsertLoginDetails(Constants.UserEmail, "@@@");
        Pages.LoginPage.ClickSignIn();
        Pages.LoginPage.IsInvalidAccountErrorMessageDisplayed().Should().BeTrue();
    }


    [TestCleanup] 
    public override void After() 
    {  
        base.After(); 
    }
}
