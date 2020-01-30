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
            _driver = new ChromeDriver(@"C:\drivers");
        }
        [Test]
        public void cssDemo()
        {
            _driver.Url = "https://localhost:44399/register";
            _driver.Manage().Window.Maximize();


            // Store locator values of email text box and sign up button				
            IWebElement loginTextBox = _driver.FindElement(By.XPath(".//*[@id='login']"));
            IWebElement passwordTextBox = _driver.FindElement(By.XPath(".//*[@id='password']"));
            IWebElement registerButton = _driver.FindElement(By.XPath(".//*[@id='registerButton']"));

            loginTextBox.SendKeys("test123@gmail.com");
            passwordTextBox.SendKeys("ptakilatajakluczem");
            registerButton.Click();

        }

    }

}
