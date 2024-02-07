# TestingEcommerceAppExercise

Project structure

Helpers Models - Models needed in the UI tests.

BaseTest- the methods that are needed to run before(browser setup) and after(browser cleanup) a test is set up.

Automation Framework: The page Object Model (POM) design pattern is used to create reusable and maintainable scripts.

Pages All the page object models are created in this folder.

Tests All the tests are created in this folder.

Pages class contains the initialization of pages.

Each test must have the data setup up before the test, and cleaned in the after method.

All the asserts will be visible in the test method, not hidden in page classes.

Tools used .net 8

MsTest as the testing framework

FluentAssertions

NsTestFrameworkUI - helpers for Selenium

Faker.Net - generates random data

Selenium

ChromeDriver