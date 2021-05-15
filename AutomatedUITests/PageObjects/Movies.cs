using System;
using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;

namespace Movies.PageObject{
   public class MoviesPage{
        String url = "\\Movies";
        private IWebDriver _driver;
        private  WebDriverWait wait;

        public MoviesPage(IWebDriver driver){
            _driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        public string getTitle(){return _driver.Title;}
        public string getUrl(){return url;}
        public WebDriverWait getWait(){return wait;}
    }
}