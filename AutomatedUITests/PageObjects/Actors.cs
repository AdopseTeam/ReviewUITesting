using System;
using Home.PageObject;
using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;

namespace Actors.PageObject{
   public class ActorsPage{
        String url = "\\Actor";
        private IWebDriver _driver;
        private  WebDriverWait wait;
        private IWebElement Element;
        HomePage home;

        public ActorsPage(IWebDriver driver){
            _driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        public string getTitle(){return _driver.Title;}
        public string getUrl(){return url;}
        public WebDriverWait getWait(){return wait;}

       public IWebElement getElement(){return Element = _driver.FindElement(By.XPath("//a[@href='"+home.getUrl()+url+"']"));}

        public void goToActorsPage()
        {
            getElement().Click();
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
              
            Element = _driver.FindElement(By.XPath("//a[@href='"+home.getUrl()+url+"/Movies?pageNumber=2']"));

            Element.Click();

            String link = _driver.Url;

            return link;

        }        

        
        public String PreviousPageClick(){
              
            Element = _driver.FindElement(By.XPath("//a[@href='"+home.getUrl()+url+"/Movies?pageNumber=1']"));

            Element.Click();

            String link = _driver.Url;

            return link;

        }  


        public IWebElement getMoreInfoBTN(){ return Element = _driver.FindElement(By.TagName("a")) ; }
    
        
        public IWebElement Info(){ 

            return  _driver.FindElement(By.ClassName("movie-title"));
            
         }  




    }
}