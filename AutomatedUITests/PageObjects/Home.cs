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

        public IWebElement getMoreInfoBTN(){ 
            return HomeEl = _driver.FindElement(By.LinkText("More info")) ; }

        public IWebElement getMoreInfoBTNActors(){ 
            return HomeEl = _driver.FindElement(By.XPath("//a[@href='"+url+"//Actor/Details/']")) ; }

        public void InfoM(){ 

            getMoreInfoBTN().Click();

         }


        public IWebElement InfoA(){ 

            getMoreInfoBTNActors().Click();

            return  _driver.FindElement(By.ClassName("movie-title"));
            
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
            HomeEl = _driver.FindElement(By.XPath("//a[@href=/]"));
            HomeEl.Click();
            
        } 

        public void ReleasedthisMonthPage()
        {
            HomeEl = _driver.FindElement(By.XPath("//*[text()='Released On May']"));
            HomeEl.Click();
            
        } 

        
        public void BornThisMonthPage()
        {
            HomeEl = _driver.FindElement(By.XPath("//*[text()='Born On May']"));
            HomeEl.Click();
            
        } 

        
        public void TopMoviesPage()
        {
            HomeEl = _driver.FindElement(By.XPath("//*[text()='Top Movies']"));
            HomeEl.Click();
            
        } 
        
            }
        
    }

            