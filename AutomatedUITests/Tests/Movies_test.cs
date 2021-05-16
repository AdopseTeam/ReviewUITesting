using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Home.PageObject;
using Movies.PageObject;
using Users.PageObject;


namespace MoviesTest
{
    [TestFixture]
    public class Movies_test
    {
        IWebDriver driver;
        String baseUrl = "https://localhost:5001";

        UsersPage users;
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
        public void CardsLoaded()
        {
            driver.Navigate().GoToUrl( baseUrl + movies.getUrl() );
            
            Assert.IsTrue(movies.ContainsCards());
    
        }

        [Test]
        public void Search()
        {
            driver.Navigate().GoToUrl( baseUrl + movies.getUrl());
            
            Assert.IsTrue(movies.SearchClick("miraculous"));

        }


        [Test]
        public void NextPage()
        {
            driver.Navigate().GoToUrl( baseUrl + movies.getUrl());
            
            Assert.IsTrue(movies.NextPageClick() == baseUrl+movies.getUrl()+"?pageNumber=2");

        }
        
        [Test]
        public void PreviusPage()
        {
            driver.Navigate().GoToUrl( baseUrl + movies.getUrl());
            
            Assert.IsTrue(movies.PreviousPageClick() == baseUrl+movies.getUrl()+"/Movies?pageNumber=1");

        }

        
        [Test]
        public void MovieInfoClick()
        {
            driver.Navigate().GoToUrl( baseUrl + movies.getUrl());

            Assert.True(movies.MoreInfo());
            
            movies.getMoreInfoBTN().Click();

            Assert.True(movies.getTitle() == "Details - Review");

            Assert.True(movies.TitleInfo() == "Movie");

        }

        [Test]
        public void BackToMoviesListClick()
        {
            driver.Navigate().GoToUrl(baseUrl);

            MovieInfoClick();

            movies.BackToMoviesListBtn();

            Assert.Equals("Index - Review", driver.Title);

        }

        //Tests for Loged users

        [Test]
        public void UserLogin()
        {
            driver.Navigate().GoToUrl( baseUrl+users.getLoginUrl());

            users.InputLoginFields("ddd@gmail.com","kAl12345!");

            Assert.Equals("Home Page - Review", driver.Title);

        }


        [Test]
        public void MovieWatchlist()
        {
            driver.Navigate().GoToUrl( baseUrl+movies.getUrl());

            MoviespageLoaded();

            MovieInfoClick();

            Assert.True(movies.WatchListClick().Equals(baseUrl+"/Watchlist")); 

            Assert.Equals(" - Review", driver.Title);

        }

        [Test]
        public void WatchlistRemove()
        {
            driver.Navigate().GoToUrl(baseUrl+"/Watchlist");

            movies.WatchListRemoveClick();
            
            Assert.Equals(" - Review", driver.Title);

        }

        [OneTimeTearDown]
         public void Close()
        {
            driver.Close();
        }
    }
}