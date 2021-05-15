using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Home.PageObject;
using Movies.PageObject;

namespace MoviesTest
{
    [TestFixture]
    public class Movies_test
    {
        IWebDriver driver;
        String baseUrl = "https:\\locahost:5001";

        MoviesPage movies;
        
        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            movies = new MoviesPage(driver);
        }

        [Test]
        public void MoviespageLoaded()
        {
            driver.Navigate().GoToUrl( baseUrl + movies.getUrl() );
            Assert.True(movies.getTitle() == "Index - Review");
        }

        [Test]
        public void MoviesClick()
        {
            driver.Navigate().GoToUrl(baseUrl);
                
            driver.FindElement(By.XPath(baseUrl+movies.getUrl())).Click();

            Assert.Equals("Index - Review", driver.Title);


        }


        [Test]
        public void LogedUserMoviesClick()
        {
            driver.Navigate().GoToUrl(baseUrl);
                
            driver.FindElement(By.XPath("//a[@href='"+baseUrl+movies.getUrl()+"']")).Click();

            Assert.Equals("Movies - Review", driver.Title);

        }

        [OneTimeTearDown]
         public void Close()
        {
            driver.Close();
        }
    }
}