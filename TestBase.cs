using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace MatchingEngineAutomation.Tests
{
    [TestFixture]
    public abstract class TestBase
    {
        protected IWebDriver Driver = null!;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            
            options.AddArgument("--window-size=1440,1000");

            Driver = new ChromeDriver(options);
        }

        [TearDown]
        public void TearDown()
        {
            Driver?.Quit();
            Driver?.Dispose();
        }
    }
}
