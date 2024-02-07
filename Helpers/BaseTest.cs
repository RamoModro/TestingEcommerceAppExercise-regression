using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkApi.RestSharp;
using NsTestFrameworkUI.Helpers;
using RestSharp;
using System.Reflection;

[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.MethodLevel)]
namespace TestingEcommerceAppExercise.Helpers;

public class BaseTest
{
    public TestContext TestContext { get; set; }
    public readonly RestClient Client = RequestHelper.GetRestClient(Constants.Url);

    [TestInitialize]
    public virtual void Before()
    {
        Browser.InitializeDriver(new DriverOptions { 
            IsHeadless = true,
            ChromeDriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
        });
        Browser.WebDriver.Manage().Window.Maximize();
    }

    [TestCleanup]
    public virtual void After()
    {
        if (TestContext.CurrentTestOutcome.Equals(UnitTestOutcome.Failed))
        {
            var path = ScreenShot.GetScreenShotPath(TestContext.TestName);
            TestContext.AddResultFile(path);
        }
        Browser.Cleanup();
    }
}
