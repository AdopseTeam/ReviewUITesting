using System;
using Home.PageObject;
using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;

namespace Movies.PageObject{
   public class MoviesPage{
        String url = "/Movies";
        private IWebDriver _driver;
        private  WebDriverWait wait;

        HomePage home;

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
            IWebElement moviesEl = _driver.FindElement(By.XPath("//a[@href='"+home.getUrl()+url+"']"));  
            moviesEl.Click();
        }    

        public Boolean ContainsCards(){

                Element = _driver.FindElement(By.ClassName("card"));

                if(Element.Equals("card"))  return true;
               
                return false;
        }

        public Boolean SearchClick(String title){
                
                _driver.FindElement(By.Id("title")).SendKeys(title);

                Element = _driver.FindElement(By.XPath("//input[@type='submit']"));

                Element.Click();

                String moviesT = _driver.FindElement(By.TagName("h5")).Text;

                if(moviesT.Contains(title)){
                    return true;
                }

                return false;

        }        


        public String NextPageClick(){
              
            Element = _driver.FindElement(By.XPath("//a[@href='"+home.getUrl()+url+"?pageNumber=2']"));

            Element.Click();

            String link = _driver.Url;

            return link;

        }        

        public String WatchListClick(){
              
            Element = _driver.FindElement(By.XPath("//a[@href='"+home.getUrl()+url+"/Watchlist/NewMovie?CurrentMovieId=']"));

            Element.Click();

            String link = _driver.Url;

            return link;

        }     

        public void WatchListRemoveClick(){
              
            Element = _driver.FindElement(By.XPath("//a[@href='"+home.getUrl()+"'/Watchlist/Remove/']"));

            Element.Click();

        } 

        

        
        public String PreviousPageClick(){
              
            Element = _driver.FindElement(By.XPath("//a[@href='"+home.getUrl()+url+"?pageNumber=1']"));

            Element.Click();

            String link = _driver.Url;

            return link;

        }


        public IWebElement getMoreInfoBTN(){ return Element = _driver.FindElement(By.TagName("a")) ; }
        
        public Boolean MoreInfo(){

             var HomeEl = getMoreInfoBTN().Text;
            
             if(HomeEl == "More info"){
                 return true;
             }

             return false;
             
            
        }
        
        public String TitleInfo(){ 

            String El;

            return El = _driver.FindElement(By.TagName("h4")).Text ;
            
         }

        public void BackToMoviesListBtn()
        {   
            Element = _driver.FindElement(By.TagName("a"));
        
            var El2 = _driver.FindElement(By.TagName("a")).Text;

            if(El2 == "/Movies"){
               Element.Click();
            } 
            
        } 

    }
}