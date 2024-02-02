using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

namespace TestingEcommerceAppExercise.Pages;

public class BasePage
{
    private readonly By _requiredErrorMessages = By.CssSelector("div.mage-error");
    private readonly By _searchErrorMessages = By.CssSelector(".message.notice");
    private readonly By _pageTitle = By.CssSelector(".page-title");
    private readonly By _unavailableMessage = By.CssSelector(".message-error");


    public List<string> GetRequiredErrorMessages()
    {
       return _requiredErrorMessages.GetElements().Select(message => message.Text).ToList();
    }

    public string GetUnavailableErrorMessages() => _unavailableMessage.GetText();

    public string GetSearchErrorMessages()
    {
        WaitHelpers.ExplicitWait();
        return _searchErrorMessages.GetText();
    }

    public int GetIntFromPrice(string priceNonFormatted)
    {
        return int.Parse(priceNonFormatted
            .Replace("$", "")
            .Replace(".", ""));
    }
    public string GetPageTitle()
    {
        _pageTitle.WaitUntilElementIsVisible();
        return _pageTitle.GetText();
    }
}
