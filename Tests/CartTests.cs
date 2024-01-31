using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkUI.Helpers;
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
    public void ProductCanBeAddedToCartTest()
    {
        Browser.GoTo(Constants.Url);
    }

    [TestCleanup]
    public override void After()
    {
        base.After();
    }
}
