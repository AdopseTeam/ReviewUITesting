using System;
using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;

namespace Actors.PageObject{
   public class ActorsPage{
        String url = "\\Actors";
        private IWebDriver _driver;
        private  WebDriverWait wait;

        public ActorsPage(IWebDriver driver){
            _driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        public string getTitle(){return _driver.Title;}
        public string getUrl(){return url;}
        public WebDriverWait getWait(){return wait;}
    }
}