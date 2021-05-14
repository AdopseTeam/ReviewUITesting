using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomatedUITests
{
    [TestFixture]
    public class Tests
    {
        IWebDriver driver;
        String baseUrl = "https:\\adopse-imdb.herokuapp.com\\";

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

       /* [Test]
        public void MovieListLoading()
        {
            driver.Navigate().GoToUrl( baseUrl+"Movies");
            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("title")).Displayed);

            IWebElement SearchInput = driver.FindElement(By.Id("title"));
            IWebElement SearchBtn = driver.FindElements(By.TagName("input"))[1];

            SearchInput.SendKeys("title");
            String val = SearchInput.Text;


            Assert.True(val != "");

           
        } */


        
        [Test]
        public void TestTopPicks()
        {
           
            driver.Navigate().GoToUrl( baseUrl);

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("title")).Displayed);
        
            IWebElement TopPicksBtn = driver.FindElements(By.TagName("button"))[8];            
           
            TopPicksBtn.Click();

            
        }

        [Test]
        public void MoviesClick()
        {
            driver.Navigate().GoToUrl(baseUrl);

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("wtw")).Displayed);
                
            driver.FindElement(By.XPath("//a[@href='"+baseUrl+"Movies']")).Click();

            Assert.Equals("Index - Review", driver.Title);


        }

        [Test]
        public void SeriesClick()
        {
            driver.Navigate().GoToUrl(baseUrl);

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("wtw")).Displayed);
                
            driver.FindElement(By.XPath("//a[@href='"+baseUrl+"Series']")).Click();

            Assert.Equals("Series - Review", driver.Title);


        }

        [Test]
        public void ActorsClick()
        {
            driver.Navigate().GoToUrl(baseUrl);

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("wtw")).Displayed);
                
            driver.FindElement(By.XPath("//a[@href='"+baseUrl+"Actor']")).Click();

            Assert.Equals("Actors - Review", driver.Title);


        }

        [Test]
        public void LoginButtonClick()
        {

            driver.Navigate().GoToUrl( baseUrl);

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("wtw")).Displayed);

            driver.FindElement(By.XPath("//a[@href='"+baseUrl+"Identity/Account/Login']")).Click();

            Assert.Equals("Login - Review", driver.Title);

            
        }

        [Test]
        public void ForgotPasswordLinkClicked()
        {

            driver.Navigate().GoToUrl( baseUrl+"Identity/Account/Login");

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("account")).Displayed);

            driver.FindElement(By.XPath("//a[@href='"+baseUrl+"Identity/Account/ForgotPassword']")).Click();

            var exists = driver.FindElement(By.TagName("h1")).Text;

            Assert.IsTrue(exists == "Forgot your password?");
            
        }

        [Test]
        public void ForgotPasswordInvalidEmailError()
        {
            driver.Navigate().GoToUrl(baseUrl+"Identity/Account/ForgotPassword");

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("account")).Displayed);

            driver.FindElement(By.Id("Input_Email"))
                .SendKeys("fsfsf12121");
        

            var errorMessage = driver.FindElement(By.ClassName("Input_Email-error")).Text;

            Assert.True(errorMessage == "The Email field is not a valid e-mail address.");

        }

        [Test]
        public void ForgotPasswordSuccess()
        {
            driver.Navigate().GoToUrl(baseUrl+"Identity/Account/ForgotPassword");

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("account")).Displayed);

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
            driver.Navigate().GoToUrl( baseUrl+"Identity/Account/Login");

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("account")).Displayed);

            driver.FindElement(By.XPath("//a[@href='"+baseUrl+"Identity/Account/ResendEmailConfirmation']")).Click();
 
            var GetId = driver.FindElement(By.TagName("h1")).Text;

            Assert.IsTrue(GetId == "Resend email confirmation");
               

        }

        [Test]
        public void ResendEmailInvalidEmailError()
        {
            driver.Navigate().GoToUrl(baseUrl+"Identity/Account/ResendEmailConfirmation");

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.TagName("form")).Displayed);

            driver.FindElement(By.Id("Input_Email"))
                .SendKeys("fsfsf12121");
        

            var errorMessage = driver.FindElement(By.ClassName("Input_Email-error")).Text;

            Assert.True(errorMessage == "The Email field is not a valid e-mail address.");

        }

        [Test]
        public void ResendEmailSuccess()
        {
            driver.Navigate().GoToUrl(baseUrl+"Identity/Account/ResendEmailConfirmation");

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.TagName("form")).Displayed);

            driver.FindElement(By.Id("Input_Email"))
                .SendKeys("fff@gmail.com");
            
            driver.FindElement(By.TagName("button"))
                .Click();

            var Message = driver.FindElement(By.ClassName("text-danger")).Text;

            Assert.True(Message == "Verification email sent. Please check your emai");

        }

        [Test]
        public void RegisterUserfromLoginPage()
        {
            driver.Navigate().GoToUrl( baseUrl+"Identity/Account/Login");

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("account")).Displayed);

            driver.FindElement(By.XPath("//a[@href='"+baseUrl+"Identity/Account/Register?returnUrl=%2F']")).Click();

            Assert.Equals("Register - Review", driver.Title);

        }

        [Test]
        public void RegisterUserfromHomePage()
        {
            driver.Navigate().GoToUrl( baseUrl);

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("wtw")).Displayed);

            driver.FindElement(By.XPath("//a[@href='"+baseUrl+"Identity/Account/Register']")).Click();

            Assert.Equals("Register - Review", driver.Title);

        }

        [Test]
        public void RegisterUserInvalidEmailError()
        {
            driver.Navigate().GoToUrl(baseUrl+"Identity/Account/Register");

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("registerForm")).Displayed);

            driver.FindElement(By.Id("Input_Email"))
                .SendKeys("fsfsf12121");

            var errorMessage = driver.FindElement(By.ClassName("Input_Email-error")).Text;

            Assert.True(errorMessage == "The Email field is not a valid e-mail address.");
            
        }

        [Test]
        public void RegisterUserPasswordLengthError()
        {
            driver.Navigate().GoToUrl(baseUrl+"Identity/Account/Register");

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("registerForm")).Displayed);

            driver.FindElement(By.Id("Input_Password"))
                .SendKeys("123");
            
            var errorMessage = driver.FindElement(By.Id("Input_Password-error")).Text;

            Assert.True(errorMessage ==
             "The Password must be at least 6 and at max 100 characters long.");
            
        }

        [Test]
        public void RegisterUserPasswordMatchError()
        {
            driver.Navigate().GoToUrl(baseUrl+"Identity/Account/Register");

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("registerForm")).Displayed);

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
            driver.Navigate().GoToUrl(baseUrl+"Identity/Account/Register");

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("registerForm")).Displayed);

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
            driver.Navigate().GoToUrl(baseUrl+"Identity/Account/Register");

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("registerForm")).Displayed);

            driver.FindElement(By.Id("Input_Email"))
                .SendKeys("ddd@gmail.com");

            var errorMessage = driver.FindElement(By.ClassName("text-danger validation-summary-errors")).Text;

            Assert.True(errorMessage == "Username ' + ' is already taken.");
            
        }

        [Test]
        public void RegisterUserSuccess()
        {
            driver.Navigate().GoToUrl(baseUrl+"Identity/Account/Register");

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("registerForm")).Displayed);

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

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("confirm-link")).Displayed);

            driver.FindElement(By.XPath("//a[@href='https://aka.ms/aspaccountconf']")).Click();
 
           

            
        }

        [Test]
        public void RegisterConfirmAccountClick()
        {
            driver.Navigate().GoToUrl(baseUrl+"Identity/Account/RegisterConfirmation?");

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("confirm-link")).Displayed);

            Assert.Equals("Register Confirmation - Review", driver.Title);



 
        }

        [Test]
        public void ConfirmAccountSuccess()
        {
            driver.Navigate().GoToUrl(baseUrl+"Identity/Account/ConfirmEmail?");

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.TagName("h1")).Displayed);

            Assert.Equals("Confirm email - Review", driver.Title);

 
        }

        [Test]
        public void UserLoginInvalidEmailError()
        {
            driver.Navigate().GoToUrl( baseUrl+"Identity/Account/Login");

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("account")).Displayed);

            driver.FindElement(By.Id("Input_Email"))
                .SendKeys("sdadav");
            

            var errorMessage = driver.FindElement(By.Id("Input_Email-error")).Text;

            Assert.True(errorMessage != "The Email field is not a valid e-mail address.");

        }

        
        [Test]
        public void InvalidLoginUserError()
        {
            driver.Navigate().GoToUrl( baseUrl+"Identity/Account/Login");

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("account")).Displayed);

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
            driver.Navigate().GoToUrl( baseUrl+"Identity/Account/Login");

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("account")).Displayed);

            var ck = driver.FindElement(By.Id("Input_RememberMe")).Selected;
                
            Assert.True(ck);
        }


        [Test]
        public void UserLoginSuccess()
        {
            driver.Navigate().GoToUrl( baseUrl+"Identity/Account/Login");

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("account")).Displayed);

            driver.FindElement(By.Id("Input_Email"))
                .SendKeys("ddd@gmail.com");
            driver.FindElement(By.Id("Input_Password"))
                .SendKeys("kAl12345!");
            driver.FindElement(By.Id("login-submit"))
                .Click();

            
            var link = driver.FindElement(By.XPath("//a[@href='"+baseUrl));

            Assert.IsTrue(link.Equals("http://adopse-imdb.herokuapp.com/"));


        }

        //TESTS FOR LOGED USERS

        [Test]
        public void LogedUserMoviesClick()
        {
            driver.Navigate().GoToUrl(baseUrl);

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("wtw")).Displayed);
                
            driver.FindElement(By.XPath("//a[@href='"+baseUrl+"Movies']")).Click();

            var getText = driver.FindElement(By.TagName("h1")).Text;

            Assert.Equals("Index - Review", driver.Title);


        }



        [Test]
        public void LogedUserSeriesClick()
        {
            driver.Navigate().GoToUrl(baseUrl);

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("wtw")).Displayed);
                
            driver.FindElement(By.XPath("//a[@href='"+baseUrl+"Series']")).Click();

            Assert.Equals("Series - Review", driver.Title);

        }

        [Test]
        public void LogedUserActorsClick()
        {
            driver.Navigate().GoToUrl(baseUrl);

            WebDriverWait wait = new WebDriverWait (driver,TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("wtw")).Displayed);
                
            driver.FindElement(By.XPath("//a[@href='"+baseUrl+"Actor']")).Click();

            Assert.Equals("Actors - Review", driver.Title);


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