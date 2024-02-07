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
        Pages.LoginPage.DoLogin(Constants.UserEmail, Constants.UserPass);
        Pages.Homepage.IsSignInLinkDisplayed().Should().BeFalse();
    }

    [TestMethod]
    public void LoginWithInvalidCredentialsTest()
    {
        Browser.GoTo(Constants.Url);

        Pages.Homepage.GoToLogin();
        Pages.LoginPage.DoLogin("invalid@mail.com", Constants.UserPass);
        Pages.LoginPage.IsInvalidAccountErrorMessageDisplayed().Should().BeTrue();
        Pages.LoginPage.DoLogin(Constants.UserEmail, "@@@");
        Pages.LoginPage.IsInvalidAccountErrorMessageDisplayed().Should().BeTrue();
    }


    [TestCleanup] 
    public override void After() 
    {  
        base.After(); 
    }
}
