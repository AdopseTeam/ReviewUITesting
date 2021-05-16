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
            driver.Navigate().GoToUrl( baseUrl);
            Assert.True(home.getTitle() == "Home Page - Review");
        }

        [Test]
        public void HomepageMovieInfoClick()
        {
            driver.Navigate().GoToUrl( baseUrl + home.getUrl());

            home.InfoM();

            Assert.True(driver.Url == baseUrl+"/Movies/Details/");            
        }

        [Test]
        public void HomepageActorsInfoClick()
        {
            driver.Navigate().GoToUrl( baseUrl + home.getUrl());

            home.InfoA();

            Assert.True(driver.Url == baseUrl + "/Actor/Details/");

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
        public void ReleasedThisMonthClick()
        {
            driver.Navigate().GoToUrl(baseUrl);
                
            home.ReleasedthisMonthPage();

            Assert.Equals("Released On This Month - Review", driver.Title);

        }

        [Test]
        public void Top10PicksClick()
        {
            driver.Navigate().GoToUrl(baseUrl);
                
            home.TopMoviesPage();

            Assert.Equals("Top Rating Movies - Review", driver.Title);

        }

        [Test]
        public void BornThisMonthClick()
        {
            driver.Navigate().GoToUrl(baseUrl);
                
            home.BornThisMonthPage();

            Assert.Equals("Born This Month - Review", driver.Title);

        }

        
       
        
        [OneTimeTearDown]
         public void Close()
        {
            driver.Close();
        }
    }
}