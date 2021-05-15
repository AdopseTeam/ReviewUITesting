using System;
using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;

namespace Users.PageObject{
   public class UsersPage{
        String urlLogin = "\\Identity\\Account\\Login";
        String urlRegister = "\\Identity\\Account\\Register";

        String urlForgotPassword = "\\Identity\\Account\\ForgotPassword";

        String urlResendEmail = "\\Identity\\Account\\ResendEmailConfirmation";

        
        private IWebDriver _driver;
        private  WebDriverWait wait;

        public UsersPage(IWebDriver driver){
            _driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        public string getTitle(){return _driver.Title;}
        public string getLoginUrl(){return urlLogin;}

        public string getRegisterUrl(){return urlRegister;}

        public string getForgotPasswordUrl(){return urlForgotPassword;}

        public string getResetEmailUrl(){return urlResendEmail;}

        public WebDriverWait getWait(){return wait;}


    }
}