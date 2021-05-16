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
            
            Assert.IsTrue(series.SearchClick("Mike & Molly"));

        }


        [Test]
        public void NextPage()
        {
            driver.Navigate().GoToUrl( baseUrl + series.getUrl());
            
            Assert.IsTrue(series.NextPageClick() == baseUrl+ series.getUrl() + "/?pageNumber=2");

        }
        
        [Test]
        public void PreviusPage()
        {
            driver.Navigate().GoToUrl( baseUrl + series.getUrl());
            
            Assert.IsTrue(series.PreviousPageClick() == baseUrl+series.getUrl()+"?pageNumber=1");

        }

        
        [OneTimeTearDown]
         public void Close()
        {
            driver.Close();
        }
    }
}