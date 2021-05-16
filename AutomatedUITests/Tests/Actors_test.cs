using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Home.PageObject;
using Actors.PageObject;

namespace ActorsTest
{
    [TestFixture]
    public class Actors_test
    {
        IWebDriver driver;
        String baseUrl = "https://localhost:5001";

        ActorsPage actors;
        
        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            actors = new ActorsPage(driver);
        }

        [Test]
        public void ActorspageLoaded()
        {
            driver.Navigate().GoToUrl( baseUrl + actors.getUrl() );
            Assert.True(actors.getTitle() == "Actors - Review");
        }

        [Test]
        public void CardsLoaded()
        {
            driver.Navigate().GoToUrl( baseUrl + actors.getUrl() );
            
            Assert.IsTrue(actors.ContainsCards());
    
        }

        [Test]
        public void Search()
        {
            driver.Navigate().GoToUrl( baseUrl + actors.getUrl());
            
            Assert.IsTrue(actors.SearchClick("Adams"));

        }


        [Test]
        public void NextPage()
        {
            driver.Navigate().GoToUrl( baseUrl + actors.getUrl());
            
            Assert.IsTrue(actors.NextPageClick() == baseUrl+ actors.getUrl() + "/?pageNumber=2");

        }
        
        [Test]
        public void PreviusPage()
        {
            driver.Navigate().GoToUrl( baseUrl + actors.getUrl());
            
            Assert.IsTrue(actors.PreviousPageClick() == baseUrl+actors.getUrl()+"?pageNumber=1");

        }

        [Test]
        public void ActorsInfoClick()
        {
            driver.Navigate().GoToUrl( baseUrl + actors.getUrl());

            Assert.True(actors.MoreInfo());
            
            actors.getMoreInfoBTN().Click();

            Assert.True(actors.getTitle() == "Details - Review");

            Assert.True(actors.TitleInfo() == "Actor");

        }

        

        [OneTimeTearDown]
         public void Close()
        {
            driver.Close();
        }
    }
}