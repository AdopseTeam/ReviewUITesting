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


        public Boolean SearchClick(String title){
                
                _driver.FindElement(By.Id("title")).SendKeys(title);

                Element = _driver.FindElement(By.XPath("//input[@type='submit' and @value='Search']"));

                Element.Click();

                String moviesT = _driver.FindElement(By.TagName("h5")).Text;

                if(moviesT.Equals(title)){
                    return true;
                }

                return false;

        }        


        public String NextPageClick(){
              
            Element = _driver.FindElement(By.LinkText("Next Page"));

            Element.Click();

            String link = _driver.Url;

            return link;

        }        


        public String PreviousPageClick(){
              
            Element = _driver.FindElement(By.LinkText("Previous Page"));

            Element.Click();

            String link = _driver.Url;

            return link;

        }

        public String WatchListClick(){
              
            Element = _driver.FindElement(By.LinkText("Add to WatchList"));

            Element.Click();

            String link = _driver.Url;

            return link;

        }     



        public void WatchListRemoveClick(){
              
            Element = _driver.FindElement(By.LinkText("Remove"));

            Element.Click();

        } 



        public IWebElement getMoreInfoBTN(){ return Element = _driver.FindElement(By.TagName("a")) ; }
    
        
        public IWebElement Info(){ 

            return  _driver.FindElement(By.ClassName("movie-title"));
            
         }

        } 

    }
