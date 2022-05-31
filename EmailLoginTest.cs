using NUnit.Framework;
using Page;
using resources;
using System;
using System.Threading.Tasks;
using Test2.sourse;
using NLog;

namespace Test2
{
    public class EmailLoginTest : BaseTest
    {
        public const string JsonWay = "jsonShop.json";
        private static Logger logger = LogManager.GetCurrentClassLogger();

        [Test]
        public void NavigateLoginWithoutPassword()
        {
            try
            {
                driver.Navigate().GoToUrl("https://tea-mail.by/");
                InitPage initPage = new InitPage(driver);
                JsonPost json = new JsonPost(JsonWay);

                logger.Trace("trace message");

                logger.Debug("debug message");

                logger.Info("info message");

                logger.Warn("warn message");

                logger.Error("error message");

                logger.Fatal("fatal message");

                var expectation = Task.Factory.StartNew(() => initPage.ClicBut1.Click());
                expectation.Wait();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                expectation = Task.Factory.StartNew(() => initPage.Logtxt.SendKeys(json.JsonMail(1, 0)));
                expectation.Wait();

                expectation = Task.Factory.StartNew(() => initPage.Logtxt.SendKeys(json.JsonMail(1, 1)));
                expectation.Wait();

                expectation = Task.Factory.StartNew(() => initPage.ClicBut2.Click());
                expectation.Wait();

                string messsge = initPage.ErrorMess.Text;

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                string expectedError = "Неправильное имя пользователя или пароль.";
                Assert.AreEqual(expectedError, messsge, $"{expectedError} != {messsge}");

            }
            catch
            {
                Screen screenshot = new Screen(driver);
                screenshot.MakeScreenshot();
            }
        }
    }
}