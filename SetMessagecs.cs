using NUnit.Framework;
using Page;
using resources;
using System;
using System.Threading.Tasks;
using Test2.sourse;

namespace Test2
{
    public class SetMessagecs : BaseTest
    {
        public const string JsonWay = "jsonMail.json";

        [Test]
        public void EmailMessage()
        {
            try
            {
                driver.Navigate().GoToUrl("https://passport.yandex.by/");
                JsonPost json = new JsonPost(JsonWay);
                InitPage initPage = new InitPage(driver);

                var expectation = Task.Factory.StartNew(() => initPage.LogTextID.SendKeys(json.JsonMail(1, 0)));
                expectation.Wait();

                expectation = Task.Factory.StartNew(() => initPage.ButLog1.Click());
                expectation.Wait();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                expectation = Task.Factory.StartNew(() => initPage.LogTextPassword.SendKeys(json.JsonMail(1, 1)));
                expectation.Wait();

                expectation = Task.Factory.StartNew(() => initPage.ButLog2.Click());
                expectation.Wait();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                expectation = Task.Factory.StartNew(() => initPage.ButMenu1.Click());
                expectation.Wait();

                expectation = Task.Factory.StartNew(() => initPage.ButMenu2.Click());
                expectation.Wait();

                try
                {
                    if (initPage.UnreadTrue.Displayed == true)
                    {
                        expectation = Task.Factory.StartNew(() => initPage.ButGetMessage.Click());
                        expectation.Wait();
                    }
                }
                catch
                {
                    throw new Exception("no incoming messages");
                }
                var a = "";
                expectation = Task.Factory.StartNew(() => a = initPage.TextMessage.Text);
                expectation.Wait();


                expectation = Task.Factory.StartNew(() => initPage.ButMessage1.Click());
                expectation.Wait();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                expectation = Task.Factory.StartNew(() => initPage.recipient.SendKeys(json.JsonMail(1, 3)));
                expectation.Wait();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                GetMessageTest getMessageTest = new GetMessageTest();
                if (getMessageTest.TextMessage() == a)
                {
                    expectation = Task.Factory.StartNew(() => initPage.text.SendKeys("Messages converge"));
                    expectation.Wait();

                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                    expectation = Task.Factory.StartNew(() => initPage.ButMessage2.Click());
                    expectation.Wait();
                }
                else
                {
                    expectation = Task.Factory.StartNew(() => initPage.text.SendKeys("Messages don't match"));
                    expectation.Wait();

                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                    expectation = Task.Factory.StartNew(() => initPage.ButMessage2.Click());
                    expectation.Wait();
                }
            }
            catch
            {
                Screen screenshot = new Screen(driver);
                screenshot.MakeScreenshot();
            }
        }
    }
}