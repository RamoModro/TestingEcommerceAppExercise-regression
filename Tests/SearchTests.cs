using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkUI.Helpers;
using TestingEcommerceAppExercise.Helpers;

namespace TestingEcommerceAppExercise.Tests;

[TestClass]
public class SearchTests : BaseTest
{
    [TestInitialize]
    public override void Before()
    {
        base.Before();
    }

    [TestMethod]
    public void SearchResultsShouldContainTheSearchedItemTest()
    {
        Browser.GoTo(Constants.Url);

        Pages.Homepage.IsSearchButtonEnabled().Should().BeFalse();
        Pages.Homepage.SearchItemByName("Top");
        Pages.Homepage.IsProductInResults("Top").Should().BeTrue();
    }

    [TestMethod]
    public void SearchResultsShouldBeSortedByPriceTest()
    {
        Browser.GoTo(Constants.Url);

        Pages.Homepage.SearchItemByName("Bag");
        Pages.Homepage.SelectSortByDropdownValue();
        Pages.Homepage.IsPriceDescending().Should().BeTrue();
    }

    [TestCleanup]
    public override void After()
    {
        base.After();
    }
}
