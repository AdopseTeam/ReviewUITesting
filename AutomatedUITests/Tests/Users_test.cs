using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Home.PageObject;
using Users.PageObject;
using Movies.PageObject;

namespace UsersTest
{
    [TestFixture]
    public class Users_test
    {
        IWebDriver driver;
        String baseUrl = "https:\\locahost:5001";

        UsersPage users;

        IWebElement userE;

        MoviesPage movies;

        
        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            users = new UsersPage(driver);
            
        }

        [Test]
        public void LoginpageLoaded()
        {
            driver.Navigate().GoToUrl( baseUrl + users.getLoginUrl() );
            Assert.True(users.getTitle() == "Log in - Review");
        }

        [Test]
        public void RegisterPageLoaded()
        {
            driver.Navigate().GoToUrl( baseUrl + users.getRegisterUrl() );
            Assert.True(users.getTitle() == "Register - Review");
        }

        [Test]
        public void LoginClick()
        {
            driver.Navigate().GoToUrl(baseUrl);
                
            driver.FindElement(By.XPath("//a[@href='"+baseUrl + users.getLoginUrl())).Click();

            Assert.Equals("Log in - Review", driver.Title);


        }

        [Test]
        public void RegisterClick()
        {
            driver.Navigate().GoToUrl(baseUrl);
                
            driver.FindElement(By.XPath("//a[@href='"+ baseUrl + users.getRegisterUrl())).Click();

            Assert.Equals("Register - Review", driver.Title);


        }


        //Test Methods for Login Page
        [Test]
        public void ForgotPasswordLinkClicked()
        {

            driver.Navigate().GoToUrl( baseUrl+users.getLoginUrl());

            driver.FindElement(By.XPath("//a[@href='"+baseUrl+users.getForgotPasswordUrl()+"']")).Click();

            Assert.Equals("Forgot your password? - Review", driver.Title);
            
        }

        [Test]
        public void ForgotPasswordInvalidEmailError()
        {
            driver.Navigate().GoToUrl(baseUrl+users.getForgotPasswordUrl());

            driver.FindElement(By.Id("Input_Email"))
                .SendKeys("fsfsf12121");
        

            var errorMessage = driver.FindElement(By.ClassName("Input_Email-error")).Text;

            Assert.True(errorMessage == "The Email field is not a valid e-mail address.");

        }

        [Test]
        public void ForgotPasswordSuccess()
        {
            driver.Navigate().GoToUrl(baseUrl+users.getForgotPasswordUrl());

            driver.FindElement(By.Id("Input_Email"))
                .SendKeys("gr@gmail.com");
            
            driver.FindElement(By.TagName("button"))
                .Click();

            var Message = driver.FindElement(By.TagName("p")).Text;

            Assert.True(Message == "Please check your email to reset your password.");

        }

        [Test]
        public void ResendEmailLinkClicked()
        {
            driver.Navigate().GoToUrl( baseUrl+users.getLoginUrl());

            driver.FindElement(By.XPath("//a[@href='"+baseUrl+users.getResetEmailUrl()+"']")).Click();

            Assert.Equals("Resend email - Review", driver.Title);
               

        }

        [Test]
        public void ResendEmailInvalidEmailError()
        {
            driver.Navigate().GoToUrl(baseUrl+users.getResetEmailUrl());

            driver.FindElement(By.Id("Input_Email"))
                .SendKeys("fsfsf12121");
        

            var errorMessage = driver.FindElement(By.ClassName("Input_Email-error")).Text;

            Assert.True(errorMessage == "The Email field is not a valid e-mail address.");

        }

         [Test]
        public void ResendEmailSuccess()
        {
            driver.Navigate().GoToUrl(baseUrl+users.getResetEmailUrl());

            driver.FindElement(By.Id("Input_Email"))
                .SendKeys("fff@gmail.com");
            
            driver.FindElement(By.TagName("button"))
                .Click();

            var Message = driver.FindElement(By.ClassName("text-danger")).Text;

            Assert.True(Message == "Verification email sent. Please check your emai");

        }

        //Test Methods for Register

         [Test]
        public void RegisterUserfromLoginPage()
        {
            driver.Navigate().GoToUrl( baseUrl+users.getLoginUrl());

            driver.FindElement(By.XPath("//a[@href='"+baseUrl+users.getRegisterUrl()+"?returnUrl=%2F']")).Click();

            Assert.Equals("Register - Review", driver.Title);

        }


        [Test]
        public void RegisterUserfromHomePage()
        {
            driver.Navigate().GoToUrl( baseUrl);


            driver.FindElement(By.XPath("//a[@href='"+baseUrl+users.getRegisterUrl()+"']")).Click();

            Assert.Equals("Register - Review", driver.Title);

        }

        [Test]
        public void RegisterUserInvalidEmailError()
        {
            driver.Navigate().GoToUrl(baseUrl+users.getRegisterUrl());

            driver.FindElement(By.Id("Input_Email"))
                .SendKeys("fsfsf12121");

            var errorMessage = driver.FindElement(By.ClassName("Input_Email-error")).Text;

            Assert.True(errorMessage == "The Email field is not a valid e-mail address.");
            
        }


        [Test]
        public void RegisterUserPasswordLengthError()
        {
            driver.Navigate().GoToUrl(baseUrl+users.getRegisterUrl());

            driver.FindElement(By.Id("Input_Password"))
                .SendKeys("123");
            
            var errorMessage = driver.FindElement(By.Id("Input_Password-error")).Text;

            Assert.True(errorMessage ==
             "The Password must be at least 6 and at max 100 characters long.");
            
        }

        [Test]
        public void RegisterUserPasswordMatchError()
        {
            driver.Navigate().GoToUrl(baseUrl+users.getRegisterUrl());

            driver.FindElement(By.Id("Input_Password"))
                .SendKeys("123");
            
            driver.FindElement(By.Id("Input_ConfirmPassword"))
                .SendKeys("1234");

            var errorMessage = driver.FindElement(By.Id("Input_ConfirmPassword-error")).Text;

            Assert.True(errorMessage ==
             "The password and confirmation password do not match.");
            
        }

        
        [Test]
        public void RegisterUserPasswordValidationError()
        {
            driver.Navigate().GoToUrl(baseUrl+users.getRegisterUrl());


            driver.FindElement(By.Id("Input_Password"))
                .SendKeys("123456");
            
            driver.FindElement(By.Id("registerSubmit"))
                .Click();

            var errorMessage = driver.FindElement(By.ClassName("text-danger validation-summary-errors")).Text;

            Assert.True(errorMessage ==
             "Passwords must have at least one non alphanumeric character.");
            
        }

        [Test]
        public void RegisterUserEmailExistsError()
        {
            driver.Navigate().GoToUrl(baseUrl+users.getRegisterUrl());


            driver.FindElement(By.Id("Input_Email"))
                .SendKeys("ddd@gmail.com");

            var errorMessage = driver.FindElement(By.ClassName("text-danger validation-summary-errors")).Text;

            Assert.True(errorMessage == "Username is already taken.");
            
        }

        [Test]
        public void RegisterUserSuccess()
        {
            driver.Navigate().GoToUrl(baseUrl+users.getRegisterUrl());

             driver.FindElement(By.Id("Input_Email"))
                .SendKeys("ddd@gmail.com");

            driver.FindElement(By.Id("Input_Password"))
                .SendKeys("Al12345!");

             driver.FindElement(By.Id("Input_ConfirmPassword"))
                .SendKeys("Al12345!");
            
            driver.FindElement(By.Id("registerSubmit"))
                .Click();

            Assert.Equals("Register confirmation - Review", driver.Title);

            
        }


        [Test]
        public void RegisterConfirmationDocsClick()
        {
            driver.Navigate().GoToUrl(baseUrl+"Identity/Account/RegisterConfirmation?");

            driver.FindElement(By.XPath("//a[@href='https://aka.ms/aspaccountconf']")).Click();
 
            
        }


        
        [Test]
        public void RegisterConfirmAccountClick()
        {
            driver.Navigate().GoToUrl(baseUrl+"Identity/Account/RegisterConfirmation?");


            Assert.Equals("Register Confirmation - Review", driver.Title);


        }

        [Test]
        public void ConfirmAccountSuccess()
        {
            driver.Navigate().GoToUrl(baseUrl+"Identity/Account/ConfirmEmail?");

            Assert.Equals("Confirm email - Review", driver.Title);

        }

        //Test Methods for Login after Register

        [Test]
        public void UserLoginInvalidEmailError()
        {
            driver.Navigate().GoToUrl( baseUrl+users.getLoginUrl());

            driver.FindElement(By.Id("Input_Email"))
                .SendKeys("sdadav");
            
            var errorMessage = driver.FindElement(By.Id("Input_Email-error")).Text;

            Assert.True(errorMessage != "The Email field is not a valid e-mail address.");

        }

        [Test]
        public void InvalidLoginUserError()
        {
            driver.Navigate().GoToUrl( baseUrl+users.getLoginUrl());

            driver.FindElement(By.Id("Input_Email"))
                .SendKeys("el@gmail.com");
            driver.FindElement(By.Id("Input_Password"))
                .SendKeys("123");
            driver.FindElement(By.Id("login-submit"))
                .Click();

            var errorMessage = driver.FindElement(By.ClassName("text-danger")).Text;

            Assert.True(errorMessage == "Invalid login attempt.");
        }

        [Test]
        public void RememberMeCheckBoxInLogin()
        {
            driver.Navigate().GoToUrl( baseUrl+users.getLoginUrl());

            var ck = driver.FindElement(By.Id("Input_RememberMe")).Selected;
                
            Assert.True(ck);
        }

        [Test]
        public void UserLoginSuccess()
        {
            driver.Navigate().GoToUrl( baseUrl+users.getLoginUrl());

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("account")).Displayed);

            driver.FindElement(By.Id("Input_Email"))
                .SendKeys("ddd@gmail.com");
            driver.FindElement(By.Id("Input_Password"))
                .SendKeys("kAl12345!");
            driver.FindElement(By.Id("login-submit"))
                .Click();

            Assert.Equals("Home Page - Review", driver.Title);

        }


        [Test]
        public void UserLogout()
        {
            driver.Navigate().GoToUrl(baseUrl);

            driver.FindElement(By.Id("logoutForm")).Click();

            Assert.Equals("Home Page - Review", driver.Title);

        }


        [OneTimeTearDown]
         public void Close()
        {
            driver.Close();
        }
    }
}