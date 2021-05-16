using System;
using Home.PageObject;
using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;

namespace Users.PageObject{
   public class UsersPage{
        String urlLogin = "/Identity/Account/Login";
        String urlRegister = "/Identity/Account/Register";

        String urlForgotPassword = "/Identity/Account/ForgotPassword";

        String urlResendEmail = "/Identity/Account/ResendEmailConfirmation";

        String urlManage = "/Identity/Account/Manage";
        private IWebElement Element;
        HomePage home;

        private IWebDriver _driver;
        private  WebDriverWait wait;

        String baseUrl = "https://adopse-imdb.herokuapp.com";

        private String errorMessage = "";
        public UsersPage(IWebDriver driver){
            _driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        public string getTitle(){return _driver.Title;}
        public string getLoginUrl(){return urlLogin;}

        public string getRegisterUrl(){return urlRegister;}

        public string getForgotPasswordUrl(){return urlForgotPassword;}

        public string getResendEmailUrl(){return urlResendEmail;}

        public string getManageUrl(){return urlManage;}

        public WebDriverWait getWait(){return wait;}


        public void EmailFieldFill(String email) {

            _driver.FindElement(By.Id("Input_Email"))
                .SendKeys(email);
            
        }

        public void PasswordFieldFill(String pass) {

            _driver.FindElement(By.Id("Input_Password"))
                .SendKeys(pass);
            
        }        

        public void PasswordConfirmField(String pass){

             _driver.FindElement(By.Id("Input_ConfirmPassword"))
                .SendKeys(pass);

        }


        public void SubmitButton(){
            _driver.FindElement(By.XPath("//input[@type='submit']")).Click();
                
        }

        public String InvalidEmailError(String email){

            EmailFieldFill(email);

            errorMessage = _driver.FindElement(By.ClassName("Input_Email-error")).Text;

            return errorMessage;

        }

        public String PasswordLengthError(String pass){
            
            PasswordFieldFill(pass);
            
            errorMessage = _driver.FindElement(By.Id("Input_Password-error")).Text;

            return errorMessage;
        }

        public String PasswordMatchError(String pass1,String pass2){

            PasswordFieldFill(pass1);
            PasswordConfirmField(pass2);



            if(!pass1.Equals(pass2)){

                errorMessage = _driver.FindElement(By.Id("Input_Password-error")).Text;

            }
            
            return errorMessage;

        }

        public String PasswordValidationError(String pass){

            PasswordFieldFill(pass);

            SubmitButton();

            errorMessage = _driver.FindElement(By.ClassName("text-danger validation-summary-errors")).Text;

            return errorMessage;
        }


        public void ConfirmAccountClick(){
            _driver.FindElement(By.Id("confirm-link")).Click();
        }

        public String UserEmailExistsError(String email){

            EmailFieldFill(email);

            SubmitButton();

            errorMessage = _driver.FindElement(By.ClassName("text-danger validation-summary-errors")).Text;

            return errorMessage;

        }

        public void InputLoginFields(String email,String pass){
            
            _driver.FindElement(By.Id("Input_Email"))
                .SendKeys(email);
            _driver.FindElement(By.Id("Input_Password"))
                .SendKeys(pass);
            _driver.FindElement(By.Id("login-submit"))
                .Click();

           }

        public String InvalidUserError(String email,String pass){

               InputLoginFields(email,pass);

               SubmitButton();

               errorMessage = _driver.FindElement(By.ClassName("text-danger")).Text;

               return errorMessage;           }

        public String RequireEmailError(String email)
        {
            EmailFieldFill(email);

            errorMessage = _driver.FindElement(By.Id("Input_Email-error")).Text;

            return errorMessage;
        }

        public String RequirePassError(String pass)
        {
            PasswordFieldFill(pass);

            errorMessage = _driver.FindElement(By.Id("Input_Password-error")).Text;

            return errorMessage;
        }

           public void Logout(){
                _driver.FindElement(By.Id("logoutForm")).Click();
           }

        public void RegiterClickFromLogin(){

            _driver.FindElement(By.XPath("//a[@href='"+baseUrl+getRegisterUrl()+"']")).Click();

        }

        public String ResendEmailSuccessText(String email)
        {
            EmailFieldFill(email);

            SubmitButton();

            errorMessage = _driver.FindElement(By.ClassName("text-danger validation-summary-errors")).Text;

            return errorMessage;
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


        public void SettingPageLoaded(){
            _driver.FindElement(By.Id("manage")).Click();
        }


        }
    }

