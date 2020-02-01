using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace PCServTests
{
    [TestFixture]
    class AddServiceSelenium
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
        public void AddNewServiceRequest_Save()
        {
            // go to out website
            _driver.Navigate().GoToUrl("https://localhost:5001");

            // click login url
            var loginLink = _driver.FindElement(By.CssSelector("[href='/new-request']"));
            loginLink.Click();

            // wait for redirect
            new WebDriverWait(_driver, TimeSpan.FromSeconds(3))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.TagName("app-add-service-request"))));

            var titleField = _driver.FindElement(By.Name("title"));
            titleField.SendKeys("jakis");

            var descriptionField = _driver.FindElement(By.Name("description"));
            descriptionField.SendKeys("opis produktu");


            var productField = _driver.FindElement(By.Name("product"));
            productField.SendKeys("to jest produkt");

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
