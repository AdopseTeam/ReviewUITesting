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
        String baseUrl = "https:\\locahost:5001";

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
        public void ActorsClick()
        {
            driver.Navigate().GoToUrl(baseUrl);
                
            driver.FindElement(By.XPath(baseUrl+actors.getUrl())).Click();

            Assert.Equals("Actors - Review", driver.Title);


        }

        
        [Test]
        public void LogedUserActorsClick()
        {
            driver.Navigate().GoToUrl(baseUrl);
                
            driver.FindElement(By.XPath("//a[@href='"+baseUrl+actors.getUrl()+"']")).Click();

            Assert.Equals("Actors - Review", driver.Title);


        }

        [OneTimeTearDown]
         public void Close()
        {
            driver.Close();
        }
    }
}