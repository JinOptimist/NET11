using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace GamerShopTestE2E
{
    public class ChatTest
    {
        private IWebDriver driverUser1;
        private IWebDriver driverUser2;
        private const string BaseUrl = "https://localhost:7001/";

        private readonly By _homePageChatNewMessageInputButton = By.XPath("//input[@id='newMessage']");

        [OneTimeSetUp]
        public void SetUp()
        {
            driverUser1 = new ChromeDriver();
            driverUser2 = new ChromeDriver();
        }

        [Test]
        public void ChatSendMessage()
        {
            AuthTest.Login(driverUser1, "admin", "123");
            AuthTest.Login(driverUser2, "user", "123");

            var chatUrl = BaseUrl + "Home/Index";

            driverUser1.Navigate().GoToUrl(chatUrl);
            driverUser2.Navigate().GoToUrl(chatUrl);

            IWebDriver sender;
            IWebDriver reciver;

            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    sender = driverUser1;
                    reciver = driverUser2;
                }
                else
                {
                    sender = driverUser2;
                    reciver = driverUser1;
                }

                var chatInput1 = sender.FindElement(_homePageChatNewMessageInputButton);
                var message = "Smile" + i;
                chatInput1.SendKeys(message);
                chatInput1.SendKeys(Keys.Enter);

                Thread.Sleep(1000);

                var chatMessagLocator = By.XPath($"//*[@class='messages']/*[@class='message']/*[@class='message-text' and text()='{message}']");

                var wait = new WebDriverWait(sender, TimeSpan.FromSeconds(2));
                var chatMessageElement = wait.Until(driver => driver.FindElement(chatMessagLocator));

                //sender.FindElement(chatMessagLocator);
            }
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            driverUser1.Close();
            driverUser2.Close();
        }
    }
}
