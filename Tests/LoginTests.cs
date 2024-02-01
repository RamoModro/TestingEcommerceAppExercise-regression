using Microsoft.VisualStudio.TestTools.UnitTesting;
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

    public void UserIsAbleToLogin(string username, string password, bool isLoggedIn)
    {

    }

    [TestCleanup] 
    public override void After() 
    {  
        base.After(); 
    }
}
