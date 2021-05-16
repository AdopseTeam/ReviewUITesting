using System;
using Home.PageObject;
using OpenQA.Selenium;
using Users.PageObject;
using OpenQA.Selenium.Support.UI;

namespace Movies.PageObject{
   public class MoviesPage{
        String url = "/Movies";

        private IWebDriver _driver;
        private  WebDriverWait wait;

        HomePage home;

        UsersPage users;

        private IWebElement Element;
        public MoviesPage(IWebDriver driver){
            _driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        public string getTitle(){return _driver.Title;}
        public string getUrl(){return url;}
        public WebDriverWait getWait(){return wait;}

        public void goToMoviesPage()
        {        
            Element = _driver.FindElement(By.XPath("//a[@href='"+home.getUrl()+url+"']"));  
            Element.Click();
        }    


        public IWebElement SearchClick(String title){
                
                _driver.FindElement(By.Id("title")).SendKeys(title);

                Element = _driver.FindElement(By.XPath("//input[@type='submit' and @value='Search']"));

                Element.Click();

                IWebElement moviesT = _driver.FindElement(By.XPath(("//*[text()='"+title+"']")));

                return moviesT;
        
        }        


        public String NextPageClick(){
              
            Element = _driver.FindElement(By.LinkText("Next"));

            Element.Click();

            String link = _driver.Url;

            return link;

        }        


        public String PreviousPageClick(){
              
            Element = _driver.FindElement(By.LinkText("Previous"));

            Element.Click();

            String link = _driver.Url;

            return link;

        }

        public IWebElement getMoreInfoBTN(){ return Element = _driver.FindElement(By.LinkText("More info")) ; }
    
        
        public void Info(){ 

            getMoreInfoBTN().Click();
            
         }

        } 

    }
