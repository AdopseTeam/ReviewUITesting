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
        String baseUrl = "https:\\locahost:5001";

        HomePage home;

        IWebElement MovieElement;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            home = new HomePage(driver);
        }

        [Test]
        public void HomepageLoaded()
        {
            driver.Navigate().GoToUrl( baseUrl + home.getUrl() );
            Assert.True(home.getTitle() == "Home Page - Review");
        }

         [Test]
        public void TestTopPicks()
        {
           
            driver.Navigate().GoToUrl( baseUrl + home.getUrl() );
        
            MovieElement = driver.FindElements(By.TagName("button"))[8];            
           
            MovieElement.Click();

            Assert.True(home.getTitle() == "Top Picks - Review");
            
        }

        [OneTimeTearDown]
         public void Close()
        {
            driver.Close();
        }
    }
}