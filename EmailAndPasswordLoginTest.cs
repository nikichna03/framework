using NLog;
using NUnit.Framework;
using Page;
using resources;
using System;
using System.Threading.Tasks;
using Test2.sourse;

namespace Test2
{
    internal class EmailAndPasswordLoginTest : BaseTest
    {
        public const string JsonWay = "jsonShop.json";
        private static Logger logger = LogManager.GetCurrentClassLogger();

        [Test]
        public void NavigateLoginAndPassword()//значение логина и пароля правильное 
        {
            try
            {
                logger.Trace("trace message");

                logger.Debug("debug message");

                logger.Info("info message");

                logger.Warn("warn message");

                logger.Error("error message");

                logger.Fatal("fatal message");

                JsonPost json = new JsonPost(JsonWay);
                InitPage initPage = new InitPage(driver);
                driver.Navigate().GoToUrl("https://tea-mail.by/");

                var expectation = Task.Factory.StartNew(() => initPage.ClicBut1.Click());
                expectation.Wait();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                expectation = Task.Factory.StartNew(() => initPage.Logtxt.SendKeys(json.JsonMail(0, 0)));
                expectation.Wait();

                expectation = Task.Factory.StartNew(() => initPage.Logtxt.SendKeys(json.JsonMail(0, 1)));
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