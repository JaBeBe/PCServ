using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace PCServTests
{
    [TestFixture]
    public class SeleniumLoginTests
    {
        IWebDriver _driver;
        [SetUp]
        public void StartBrowser()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AcceptInsecureCertificates = true;
            _driver = new FirefoxDriver(options);
        }
        [Test]
        public void RedirectToDashboardAfterAuthentication()
        {
            // go to out website
            _driver.Navigate().GoToUrl("https://localhost:5001");

            // click login url
            var loginLink = _driver.FindElement(By.CssSelector("[href='/login']"));
            loginLink.Click();

            // wait for redirect
            new WebDriverWait(_driver, TimeSpan.FromSeconds(3))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.TagName("app-login"))));

            // get login field and fill with login
            var loginField = _driver.FindElement(By.Name("login"));
            loginField.SendKeys("jankow");

            // get password field and fill with password
            var passwordField = _driver.FindElement(By.Name("password"));
            passwordField.SendKeys("password");

            // get submit button and send form
            var submitButton = _driver.FindElement(By.CssSelector("[type='submit']"));
            submitButton.Click();

            // wait for reload
            new WebDriverWait(_driver, TimeSpan.FromSeconds(3))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.TagName("app-dashboard"))));

            StringAssert.StartsWith("https://localhost:5001/dashboard", _driver.Url);
        }
        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
        }
    }
}