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
        String baseUrl = "https:\\locahost:5001";

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
        public void LogedUserSeriesClick()
        {
            driver.Navigate().GoToUrl(baseUrl);

                
            driver.FindElement(By.XPath("//a[@href='"+baseUrl+series.getUrl()+"']")).Click();

            Assert.Equals("Series - Review", driver.Title);

        }

        
        [OneTimeTearDown]
         public void Close()
        {
            driver.Close();
        }
    }
}