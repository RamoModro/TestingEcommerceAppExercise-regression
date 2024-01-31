﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkApi.RestSharp;
using NsTestFrameworkUI.Helpers;
using RestSharp;
using System.Reflection;

namespace TestingEcommerceAppExercise.Helpers;

public class BaseTest
{
    public TestContext TestContext { get; set; }
    public readonly RestClient Client = RequestHelper.GetRestClient(Constants.Url);

    [TestInitialize]
    public virtual void Before()
    {
        Browser.InitializeDriver(new DriverOptions { 
            IsHeadless = false,
            ChromeDriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
        });
        Browser.WebDriver.Manage().Window.Maximize();
    }

    [TestCleanup]
    public virtual void After()
    {
         Browser.Cleanup();
    }
}