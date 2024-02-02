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
        Pages.Homepage.Search("Top");
        Pages.Homepage.IsProductInResults("Top").Should().BeTrue();
    }

    [TestMethod]
    public void SearchResultsShouldBeSortedByPriceTest()
    {
        Browser.GoTo(Constants.Url);

        Pages.Homepage.Search("Bag");
        Pages.Homepage.SelectSortByDropdownValue();
        Pages.Homepage.IsPriceDescending().Should().BeTrue();
    }

    [TestMethod]
    public void CheckErrorMessagesWhenSearchingInvalidData()
    {
        Browser.GoTo(Constants.Url);

        Pages.Homepage.Search("22");
        Pages.Homepage.GetSearchErrorMessages().Should().Contain("Minimum Search query length is 3");
        Pages.Homepage.Search("@@@");
        Pages.Homepage.GetSearchErrorMessages().Should().BeEquivalentTo("Your search returned no results.");
    }

    [TestCleanup]
    public override void After()
    {
        base.After();
    }
}
