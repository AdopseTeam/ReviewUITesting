using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Home.PageObject;
using Series.PageObject;

namespace SeriesTest
{
    [TestFixture]
    public class Series_test
    {
        IWebDriver driver;
        String baseUrl = "https://localhost:5001";

        SeriesPage series;
        
        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            series = new SeriesPage(driver);
        }

        [Test]
        public void SeriespageLoaded()
        {
            driver.Navigate().GoToUrl( baseUrl + series.getUrl() );
            Assert.True(series.getTitle() == "Series - Review");
        }

        [Test]
        public void SeriesClick()
        {
            driver.Navigate().GoToUrl(baseUrl);
                
            driver.FindElement(By.XPath(baseUrl+series.getUrl())).Click();

            Assert.Equals("Series - Review", driver.Title);

        }


      [Test]
        public void Search()
        {
            driver.Navigate().GoToUrl( baseUrl + series.getUrl());
            
            Assert.IsTrue(series.SearchClick("American Horror Story"));

        }

        
        [Test]
        public void SeriesInfoClick()
        {
            driver.Navigate().GoToUrl( baseUrl + series.getUrl());

            series.getMoreInfoBTN();

            Assert.IsTrue(series.Info().Equals("movie-title"));

        }
        

        

        [Test]
        public void NextPage()
        {
            driver.Navigate().GoToUrl( baseUrl + series.getUrl());
            
            Assert.IsTrue(series.NextPageClick() == baseUrl+series.getUrl()+"?pageNumber=2");

        }
        
        [Test]
        public void PreviusPage()
        {
            driver.Navigate().GoToUrl( baseUrl + series.getUrl());
            
            Assert.IsTrue(series.PreviousPageClick() == baseUrl+series.getUrl()+"/Series?pageNumber=1");

        }

        
        [Test]
        public void MovieInfoClick()
        {
            driver.Navigate().GoToUrl( baseUrl + series.getUrl());

            series.getMoreInfoBTN();

            Assert.IsTrue(series.Info().Equals("movie-title"));

        }
        
        
        [OneTimeTearDown]
         public void Close()
        {
            driver.Close();
        }
    }
}