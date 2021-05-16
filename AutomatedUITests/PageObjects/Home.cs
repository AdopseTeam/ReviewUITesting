using System;
using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;

namespace Home.PageObject{
   public class HomePage{
        String url = "";

        private IWebDriver _driver;

        private  WebDriverWait wait;

        private IWebElement HomeEl;

        public HomePage(IWebDriver driver){
            _driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        public string getTitle(){return _driver.Title;}

        public string getUrl(){return url;}

        public WebDriverWait getWait(){return wait;}

        public IWebElement getMoreInfoBTN(){ return HomeEl = _driver.FindElement(By.TagName("a")) ; }
        
        public Boolean MoreInfo(){

             var HomeEl = getMoreInfoBTN().Text;
            
             if(HomeEl == "More info"){
                 return true;
             }

             return false;
             
            
        }

        public String TitleInfo(){ 

            String HomeEl;

            return HomeEl = _driver.FindElement(By.TagName("h4")).Text ;
             }


        public Boolean ContainsCards(){
                HomeEl = _driver.FindElement(By.ClassName("card"));

                if(HomeEl.Equals("card"))  return true;
               
                return false;
        }


        public void goToMoviesPage()
        {
            HomeEl = _driver.FindElement(By.XPath("//a[@href='"+url+"/Movies']"));
            HomeEl.Click();
        }    

        public void goToActorsPage()
                {
                    HomeEl = _driver.FindElement(By.XPath("//a[@href='"+url+"/Actor']"));
                    HomeEl.Click();
                } 
        public void goToSeriesPage()
                {
                    HomeEl = _driver.FindElement(By.XPath("//a[@href='"+url+"/Series']"));
                    HomeEl.Click();
                }  
        
        public void goToLoginPage()
        {
            HomeEl = _driver.FindElement(By.XPath("//a[@href='"+url+"/Identity/Account/Login']"));
            HomeEl.Click();
        }   

        public void goToRegisterPage()
        {
            HomeEl = _driver.FindElement(By.XPath("//a[@href='"+url+"/Identity/Account/Register']"));
            HomeEl.Click();
        } 


        public void LogoHomePage()
        {
            HomeEl = _driver.FindElement(By.TagName("a"));
            var HomeEl2 = _driver.FindElement(By.TagName("a")).Text;

            if(HomeEl2 == "/"){
               HomeEl.Click();
            } 
            
        } 

        public void BackToMoviesListBtn()
        {
            HomeEl = _driver.FindElement(By.TagName("a"));
            var HomeEl2 = _driver.FindElement(By.TagName("a")).Text;

            if(HomeEl2 == "/Movies"){
               HomeEl.Click();
            } 
            
        } 

        public void BackToActorsListBtn()
        {
            HomeEl = _driver.FindElement(By.TagName("a"));
            var HomeEl2 = _driver.FindElement(By.TagName("a")).Text;

            if(HomeEl2 == "/Actors"){
               HomeEl.Click();
            } 
            
        } 
        
            }
        
    }

            