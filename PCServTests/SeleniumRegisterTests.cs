using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
namespace PCServTests
{
    [TestFixture]
    public class FirstTests
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
        [Obsolete]
        public void registerForm_sendOnly_ValidateForm()
        {
            _driver.Navigate().GoToUrl("https://localhost:5001");
            _driver.Manage().Window.Maximize();

            var register_link = _driver.FindElement(By.CssSelector("[href='/register']"));
            register_link.Click();

            IWebElement loginTextBox = _driver.FindElement(By.XPath(".//*[@id='login']"));
            IWebElement passwordTextBox = _driver.FindElement(By.XPath(".//*[@id='password']"));
            IWebElement registerButton = _driver.FindElement(By.XPath(".//*[@id='registerButton']"));

            loginTextBox.SendKeys("1");
            passwordTextBox.SendKeys("1");
            registerButton.Click();

            // nie mogłem zaimplementować ExpectedConditions.not aby weryfikować czy element nie jest klikalny więc zrobiłem to tak :(
            try
            {
                _driver.FindElement((By.TagName("app-dashboard")));
            }
            catch (NoSuchElementException)
            {
                loginTextBox.SendKeys("1");
                passwordTextBox.SendKeys("1");

                new WebDriverWait(_driver, TimeSpan.FromSeconds(3))
                  .Until(ExpectedConditions.ElementToBeClickable(registerButton));

            }


        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
        }

    }
    
}
