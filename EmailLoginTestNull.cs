using Page;
using NUnit.Framework;
using System.Threading.Tasks;
using System;
using resources;
using NLog;

namespace Test2
{
    public class EmailLoginTestNull : BaseTest
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        [Test]
        public void NavigateLoginNull()
        {
            try
            {
                logger.Trace("trace message");

                logger.Debug("debug message");

                logger.Info("info message");

                logger.Warn("warn message");

                logger.Error("error message");

                logger.Fatal("fatal message");

                driver.Navigate().GoToUrl("https://tea-mail.by/");
                InitPage initPage = new InitPage(driver);

                var expectation = Task.Factory.StartNew(() => initPage.ClicBut1.Click());
                expectation.Wait();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                expectation = Task.Factory.StartNew(() => initPage.ClicBut2.Click());
                expectation.Wait();

                string messsge = initPage.ErrorMessage.Text;

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                string expectedError = "Логин обязателен";
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
