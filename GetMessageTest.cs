using NLog;
using NUnit.Framework;
using Page;
using resources;
using System;
using System.Threading.Tasks;
using Test2.sourse;

namespace Test2
{
    public class GetMessageTest : BaseTest
    {
        public const string JsonWay = "jsonMail.json";
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public const string SendMessagText = "TEST";

        public string TextMessage()
        {
            return SendMessagText;
        }

        [Test]
        public void EmailMessage()
        {
            try
            {
                logger.Trace("trace message");

                logger.Debug("debug message");

                logger.Info("info message");

                logger.Warn("warn message");

                logger.Error("error message");

                logger.Fatal("fatal message");

                driver.Navigate().GoToUrl("https://passport.yandex.by/");
                InitPage initPage = new InitPage(driver);
                JsonPost json = new JsonPost(JsonWay);

                var expectation = Task.Factory.StartNew(() => initPage.LogTextID.SendKeys(json.JsonMail(0, -5)));
                expectation.Wait();

                expectation = Task.Factory.StartNew(() => initPage.ButLog1.Click());
                expectation.Wait();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                expectation = Task.Factory.StartNew(() => initPage.LogTextPassword.SendKeys(json.JsonMail(0, 1)));
                expectation.Wait();

                expectation = Task.Factory.StartNew(() => initPage.ButLog2.Click());
                expectation.Wait();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                expectation = Task.Factory.StartNew(() => initPage.ButMenu1.Click());
                expectation.Wait();

                expectation = Task.Factory.StartNew(() => initPage.ButMenu2.Click());
                expectation.Wait();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                expectation = Task.Factory.StartNew(() => initPage.ButMessage1.Click());
                expectation.Wait();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                expectation = Task.Factory.StartNew(() => initPage.recipient.SendKeys(json.JsonMail(0, 2)));
                expectation.Wait();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                expectation = Task.Factory.StartNew(() => initPage.text.SendKeys(SendMessagText));
                expectation.Wait();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                expectation = Task.Factory.StartNew(() => initPage.ButMessage2.Click());
                expectation.Wait();
            }
            catch
            {
                Screen screenshot = new Screen(driver);
                screenshot.MakeScreenshot();
            }
        }
    }
}
