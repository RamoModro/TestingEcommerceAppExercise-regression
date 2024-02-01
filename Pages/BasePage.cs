using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

namespace TestingEcommerceAppExercise.Pages;

public class BasePage
{
    private readonly By _errorMessages = By.CssSelector("div.mage-error");


    public List<string> GetErrorMessages()
    {
        WaitHelpers.ExplicitWait();
        return _errorMessages.GetElements().Select(message  => message.Text).ToList();
    }
}
