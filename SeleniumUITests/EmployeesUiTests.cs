
using System;
using System.Drawing.Imaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.PhantomJS;

namespace UITestingProject
{
    public class UITest: IDisposable
    {
        private readonly IWebDriver driver;
        public UITest()
        {
            driver = new ChromeDriver();
        }
        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void Create_GET_ReturnsCreateView()
        {
            driver.Navigate().GoToUrl("http://54.236.246.7/Register/Create");

            Assert.Equal("Create Record - MyAppT", driver.Title);
            Assert.Contains("Create Record", driver.PageSource);
        }

        [Fact]
        public void Create_POST_InvalidModel()
        {
            driver.Navigate().GoToUrl("http://54.236.246.7/Register/Create");

            driver.FindElement(By.Id("Name")).SendKeys("Test");

            driver.FindElement(By.Id("Age")).SendKeys("30");

            driver.FindElement(By.ClassName("btn-primary")).Click();

            var errorMessage = driver.FindElement(By.CssSelector(".validation-summary-errors > ul > li")).Text;

            Assert.Equal("The field Age must be between 40 and 60.", errorMessage);
        }

        [Fact]
        public void Create_POST_ValidModel()
        {
            driver.Navigate().GoToUrl("http://54.236.246.7/Register/Create");

            driver.FindElement(By.Id("Name")).SendKeys("Test");

            driver.FindElement(By.Id("Age")).SendKeys("40");

            driver.FindElement(By.ClassName("btn-primary")).Click();

            Assert.Equal("Records - MyAppT", driver.Title);
            Assert.Contains("Test", driver.PageSource);
            Assert.Contains("40", driver.PageSource);
        }
    }
}