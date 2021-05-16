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
        String baseUrl = "https://localhost:5001";

        HomePage home;

        IWebElement Element;

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
        public void HomepageCardsLoding()
        {
            driver.Navigate().GoToUrl( baseUrl + home.getUrl() );
            
            Assert.IsTrue(home.ContainsCards());
    
        }

        [Test]
        public void HomepageMovieInfoClick()
        {
            driver.Navigate().GoToUrl( baseUrl + home.getUrl());

            Assert.True(home.MoreInfo());
            
            home.getMoreInfoBTN().Click();

            Assert.True(home.getTitle() == "Details - Review");

            Assert.True(home.TitleInfo() == "Movie");

        }

        [Test]
        public void HomepageActorsInfoClick()
        {
            driver.Navigate().GoToUrl( baseUrl + home.getUrl());

            Assert.True(home.MoreInfo());
            
            home.getMoreInfoBTN().Click();

            Assert.True(home.getTitle() == "Details - Review");

            Assert.True(home.TitleInfo() == "Actor");

        }


        [Test]
        public void MoviesClick()
        {
            driver.Navigate().GoToUrl(baseUrl);
                        
            home.goToMoviesPage();

            Assert.Equals("Index - Review", driver.Title);

        }

        [Test]
        public void ActorsClick()
        {
            driver.Navigate().GoToUrl(baseUrl);
                
            home.goToActorsPage();

            Assert.Equals("Actors - Review", driver.Title);

        }

        [Test]
        public void SeriesClick()
        {
            driver.Navigate().GoToUrl(baseUrl);
                
            home.goToSeriesPage();

            Assert.Equals("Series - Review", driver.Title);

        }

        [Test]
        public void LoginClick()
        {
            driver.Navigate().GoToUrl(baseUrl);
                
            home.goToLoginPage();

            Assert.Equals("Log in - Review", driver.Title);

        }

        [Test]
        public void RegisterClick()
        {
            driver.Navigate().GoToUrl(baseUrl);
                
            home.goToRegisterPage();

            Assert.Equals("Register - Review", driver.Title);

        }

        [Test]
        public void LogoClick()
        {
            driver.Navigate().GoToUrl(baseUrl);
                
            home.LogoHomePage();

            Assert.Equals("Home Page - Review", driver.Title);

        }

        [Test]
        public void BackToMoviesListClick()
        {
            driver.Navigate().GoToUrl(baseUrl);

            HomepageMovieInfoClick();

            home.BackToMoviesListBtn();

            Assert.Equals("Index - Review", driver.Title);

        }

        [Test]
        public void BackToActorsListClick()
        {
            driver.Navigate().GoToUrl(baseUrl);
            
            HomepageMovieInfoClick();

            home.BackToMoviesListBtn();

            Assert.Equals("Index - Review", driver.Title);

        }
       

        
        [OneTimeTearDown]
         public void Close()
        {
            driver.Close();
        }
    }
}