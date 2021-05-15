using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Home.PageObject;

namespace HomepageTest
{
    [TestFixture]
    public class Homepage_test
    {
        IWebDriver driver;
        String baseUrl = "https:\\locahost:5000";

        HomePage home;
        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            home = new HomePage(driver);
        }


        public void HomepageLoaded()
        {
            driver.Navigate().GoToUrl( baseUrl + home.getUrl() );
            Assert.True(home.getTitle() == "Home Page - Review");
        }

        [OneTimeTearDown]
         public void Close()
        {
            driver.Close();
        }
    }
}