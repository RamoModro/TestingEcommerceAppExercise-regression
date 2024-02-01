using Faker;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkUI.Helpers;
using TestingEcommerceAppExercise.Helpers;
using TestingEcommerceAppExercise.Helpers.Models;

namespace TestingEcommerceAppExercise.Tests;

[TestClass]
public class RegisterTests : BaseTest
{
    private static readonly Customer EmptyData = new()
    {
        FirstName = string.Empty,
        LastName = string.Empty,
        Email = string.Empty,
        Password = string.Empty,
    };

    private static readonly Customer InvalidData = new()
    {
        Email = RandomNumber.Next(50).ToString(),
        Password = RandomNumber.Next(5).ToString(),
    };

    public static IEnumerable<object[]> User()
    {
        yield return new object[] { EmptyData, Messages.NewCustomerFormEmptyFieldsErrorMessages };
        yield return new object[] { InvalidData, Messages.NewCustomerFormInvalidDataErrorMessages };
    }

    [TestInitialize]
    public override void Before()
    {
        base.Before();
    }

    [TestMethod]
    public void RegisterNewCustomerTest()
    {
        Browser.GoTo(Constants.Url);

        Pages.Homepage.GoToCreateAccount();
        Pages.CreateNewAccountPage.InsertUserDetails(new Customer());
        Pages.CreateNewAccountPage.IsSuccessMessageDisplayed().Should().BeTrue();
        Pages.Homepage.IsCreateAccountLinkDisplayed().Should().BeFalse();
    }

    [DynamicData(nameof(User), DynamicDataSourceType.Method)]
    [TestMethod]
    public void RegisterCustomerWithInvalidDataTest(Customer user, List<string> errorMessages)
    {
        Browser.GoTo(Constants.Url);

        Pages.Homepage.GoToCreateAccount();
        Pages.CreateNewAccountPage.InsertUserDetails(user);
        Pages.CreateNewAccountPage.GetErrorMessages().Should().BeEquivalentTo(errorMessages);
    }    

    [TestCleanup]
    public override void After() 
    { 
        base.After();
    }
}
