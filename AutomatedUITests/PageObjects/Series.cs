using System;
using Home.PageObject;
using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;

namespace Series.PageObject{
   public class SeriesPage{
        String url = "/Series";
        private IWebDriver _driver;
        private  WebDriverWait wait;

        private IWebElement Element;

        HomePage home;

        public SeriesPage(IWebDriver driver){
            _driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        public string getTitle(){return _driver.Title;}
        public string getUrl(){return url;}
        public WebDriverWait getWait(){return wait;}

        public IWebElement getPathElement(){return Element = _driver.FindElement(By.XPath("//a[@href='"+home.getUrl()+url+"']"));}

        public void goToSeriesPage()
        {
            getPathElement().Click();
            
        }  

        public void BackToSeriesListBtn()
        {
            var HomeEl2 = _driver.FindElement(By.TagName("a")).Text;

            if(HomeEl2 == "/Series"){
               Element.Click();
            } 
            
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
        
        public String PreviousPageClick(){
              
            Element = _driver.FindElement(By.XPath("//a[@href='"+home.getUrl()+url+"?pageNumber=1']"));

            Element.Click();

            String link = _driver.Url;

            return link;

        }

        
    }
}