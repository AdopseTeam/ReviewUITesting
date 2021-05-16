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
  public IWebElement SearchClick(String title){
                
                _driver.FindElement(By.Id("title")).SendKeys(title);

                Element = _driver.FindElement(By.XPath("//input[@type='submit' and @value='Search']"));

                Element.Click();

                IWebElement T = _driver.FindElement(By.XPath(("//*[text()='"+title+"']")));

                return T;

        }               


        public String PreviousPageClick(){
              
            Element = _driver.FindElement(By.LinkText("Previous"));

            Element.Click();

            String link = _driver.Url;

            return link;

        }

        
        public String NextPageClick(){
              
            Element = _driver.FindElement(By.LinkText("Next"));

            Element.Click();

            String link = _driver.Url;

            return link;

        }       


        public IWebElement getMoreInfoBTN(){
             return Element = _driver.FindElement(By.LinkText("More info")) ; }
    

    }
}