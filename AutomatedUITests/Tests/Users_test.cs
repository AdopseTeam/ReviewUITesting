using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Home.PageObject;
using Users.PageObject;
using Movies.PageObject;
using Actors.PageObject;

namespace UsersTest
{
    [TestFixture]
    public class Users_test
    {
        IWebDriver driver;
        String baseUrl = "https://localhost:5001";

        UsersPage users;

        MoviesPage movies;

        ActorsPage actors;
        
        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            users = new UsersPage(driver);
            
        }

        //Test Methods for Register

  
        [Test]
        public void RegisterPageLoaded()
        {
            driver.Navigate().GoToUrl( baseUrl + users.getRegisterUrl() );
            Assert.True(users.getTitle() == "Register - Review");
        }


        [Test]
        public void RegisterUserInvalidEmailError()
        {
            driver.Navigate().GoToUrl(baseUrl+users.getRegisterUrl());

            Assert.True(users.InvalidEmailError("fsfsf12121").Equals("The Email field is not a valid e-mail address."));
            
        }


        [Test]
        public void RegisterUserPasswordLengthError()
        {
            driver.Navigate().GoToUrl(baseUrl+users.getRegisterUrl());

            Assert.True(users.PasswordLengthError("123").
            Equals("The Password must be at least 6 and at max 100 characters long."));
            
        }

        [Test]
        public void RegisterUserPasswordMatchError()
        {
            driver.Navigate().GoToUrl(baseUrl+users.getRegisterUrl());    
            
            Assert.True(users.PasswordMatchError("1234","123").Equals(
             "The password and confirmation password do not match."));
            
        }

        
        [Test]
        public void RegisterUserPasswordValidationError()
        {
            driver.Navigate().GoToUrl(baseUrl+users.getRegisterUrl());

            Assert.True(users.PasswordValidationError("123456").Contains(
             "Passwords must have at least one non alphanumeric character."));
            
        }

        [Test]
        public void RegisterUserEmailExistsError()
        {
            driver.Navigate().GoToUrl(baseUrl+users.getRegisterUrl());

            Assert.True(users.UserEmailExistsError("ddd@gmail.com").
            Equals("Username is already taken."));
            
        }

        [Test]
        public void RegisterUserSuccess()
        {
            driver.Navigate().GoToUrl(baseUrl+users.getRegisterUrl());

            users.EmailFieldFill("test@gmail.com");

            users.PasswordFieldFill("Al12345!");

            users.PasswordConfirmField("Al12345!");
            
            users.SubmitButton();

            Assert.Equals("Register confirmation - Review", driver.Title);

            users.ConfirmAccountClick();

            Assert.Equals("Register Confirmation - Review", driver.Title);

            
            Assert.Equals("Confirm email - Review", driver.Title);
            
        }

    

        //Test Methods for Login Page

        [Test]
        public void LoginpageLoaded()
        {
            driver.Navigate().GoToUrl( baseUrl + users.getLoginUrl() );
            Assert.True(users.getTitle() == "Log in - Review");
        }

        [Test]
        public void UserLoginInvalidEmailError()
        {
            driver.Navigate().GoToUrl( baseUrl+users.getLoginUrl());


            Assert.True(users.InvalidEmailError("fsfsf12121").Equals("The Email field is not a valid e-mail address."));
            

        }


        [Test]
        public void UserLoginRequireEmailError()
        {
            driver.Navigate().GoToUrl( baseUrl+users.getLoginUrl());

            Assert.True(users.RequireEmailError("").Equals("The Email field is required."));
            
        }

        [Test]
        public void UserLoginRequirePasswordError()
        {
            driver.Navigate().GoToUrl( baseUrl+users.getLoginUrl());

            Assert.True(users.RequireEmailError("").Equals("The Password field is required."));
            
        }

        

        [Test]
        public void InvalidLoginUserError()
        {
            driver.Navigate().GoToUrl( baseUrl+users.getLoginUrl());

            var errorMessage = driver.FindElement(By.ClassName("text-danger")).Text;

            Assert.True(users.InvalidUserError("el@gmail.com","1234").Equals
                    ("Invalid login attempt."));
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

            users.InputLoginFields("test@gmail.com","kAl12345!");

            Assert.Equals("Home Page - Review", driver.Title);


        }
        
        [Test]
        public void MoviespageLoaded()
        {
            driver.Navigate().GoToUrl( baseUrl + movies.getUrl() );
            Assert.True(movies.getTitle() == "Index - Review");
        }

        [Test]
        public void MovieInfoClick()
        {
            driver.Navigate().GoToUrl( baseUrl + movies.getUrl());

            movies.getMoreInfoBTN();

            Assert.True(driver.Url == baseUrl+"/Movies/Details/");

        }

        [Test]
        public void ActorInfoClick()
        {
            driver.Navigate().GoToUrl( baseUrl + actors.getUrl());

            movies.getMoreInfoBTN();

            Assert.True(driver.Url == baseUrl+"/Actor/Details/");

        }

        [Test]
        public void MovieWatchlist()
        {
            driver.Navigate().GoToUrl( baseUrl+movies.getUrl());

            MoviespageLoaded();

            MovieInfoClick();

            Assert.True(users.WatchListClick().Equals(baseUrl+"/Watchlist")); 

            Assert.Equals(" - Review", driver.Title);

        }

        [Test]
        public void WatchlistRemove()
        {
            driver.Navigate().GoToUrl(baseUrl+"/Watchlist");

            users.WatchListRemoveClick();
            
            Assert.Equals(" - Review", driver.Title);

        }


        [Test]
        public void UserLogout()
        {
            driver.Navigate().GoToUrl(baseUrl);

            users.Logout();

            Assert.Equals("Home Page - Review", driver.Title);

        }

       [Test]
        public void RegisterUserfromLoginPageLoaded()
        {
            driver.Navigate().GoToUrl( baseUrl+users.getLoginUrl());

            users.RegiterClickFromLogin();

            Assert.Equals("Register - Review", driver.Title);

        }
        
        [Test]
        public void LoginPageForgotPasswordPageLoaded()
        {
            driver.Navigate().GoToUrl(baseUrl+users.getForgotPasswordUrl());

            Assert.Equals("Forgot your password? - Review", driver.Title);

        }

        [Test]
        public void ForgotPasswordInvalidEmail()
        {
            driver.Navigate().GoToUrl(baseUrl+baseUrl+users.getForgotPasswordUrl());

            Assert.True(users.InvalidEmailError("ddd").Equals
                    ("The Email field is not a valid e-mail address."));
        }

        
        [Test]
        public void ForgotPasswordSuccess()
        {
            driver.Navigate().GoToUrl(baseUrl+baseUrl+users.getForgotPasswordUrl());

            users.EmailFieldFill("ddd@gmail.com");

            users.SubmitButton();

            Assert.Equals("Forgot password confirmation - Review", driver.Title);

        }


        [Test]
        public void ResendEmailPageLoad()
        {
            driver.Navigate().GoToUrl(baseUrl+baseUrl+users.getResendEmailUrl());

            Assert.Equals("Resend Email confirmation - Review", driver.Title);

        }
        
        [Test]
        public void ResendEmailInalidEmail()
        {
            driver.Navigate().GoToUrl(baseUrl+baseUrl+users.getResendEmailUrl());

            Assert.True(users.InvalidEmailError("ddd").Equals
                    ("The Email field is not a valid e-mail address."));

        }


        [Test]
        public void ResendEmailSuccess()
        {
            driver.Navigate().GoToUrl(baseUrl+baseUrl+users.getResendEmailUrl());

            Assert.True(users.ResendEmailSuccessText("ddd@gmail.com").
            Equals("Verification email sent. Please check your email."));

        }


        [Test]
        public void ManagePageLoaded()
        {
            driver.Navigate().GoToUrl( baseUrl + users.getManageUrl() );
            Assert.True(users.getTitle() == "Profile - Review");
        }

        [OneTimeTearDown]
         public void Close()
        {
            driver.Close();
        }
    }
}