using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.DevTools.V115.SystemInfo;

namespace GamerShopTestE2E
{
    public class AuthTest
    {
        private IWebDriver driver;

        private const string BaseUrl = "https://localhost:7001/";
        
        private static readonly By _loginPageLoginInputButton = By.XPath("//input[@id='Login']");
        private static readonly By _loginPagePasswordInputButton = By.XPath("//input[@id='Password']");
        private static readonly By _loginPageSubmitButton = By.XPath("//input[@type='submit']");

        private static readonly By _profilePageUserNameSpan = By.XPath("//span[@class='user-name']");

        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        [Test]
        [TestCase("Admin", "123")]
        [TestCase("User", "123")]
        public void LoginTest(string userName, string password)
        {
            Login(driver ,userName, password);

            Assert.AreEqual(BaseUrl + "Home/Privacy", driver.Url);

            driver.Navigate().GoToUrl(BaseUrl + "User/Profile");

            var userNameAfterLogin = driver.FindElement(_profilePageUserNameSpan).Text;

            Assert.AreEqual(userName, userNameAfterLogin);
        }

        [Test]
        public void CheckRedirectToLoginToGuess()
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl(BaseUrl + "Auth/Logout");
            driver.Navigate().GoToUrl(BaseUrl + "User/Profile");

            Assert.AreEqual(BaseUrl + "Auth/Login?ReturnUrl=%2FUser%2FProfile", driver.Url);
        }

        [OneTimeTearDown]
        public void TeadDown()
        {
            driver.Close();
        }

        public static void Login(IWebDriver webDriver, string userName, string password)
        {
            webDriver.Navigate().GoToUrl(BaseUrl + "Auth/Login");

            webDriver.FindElement(_loginPageLoginInputButton).SendKeys(userName);
            webDriver.FindElement(_loginPagePasswordInputButton).SendKeys(password);
            webDriver.FindElement(_loginPageSubmitButton).Click();
        }
    }
}
