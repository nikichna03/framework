using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using WebDriverManager.DriverConfigs.Impl;

namespace Test2
{
    public class BaseTest
    {

        protected IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            string browserName = "Chrome";
            //string browserName = "Firefox";
            //string browserName = "ie";

            switch (browserName.ToUpper())
            {
                case "CHROME":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    this.driver = new ChromeDriver();
                    break;
                case "FIREFOX":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    this.driver = new ChromeDriver();
                    break;
                case "IE":
                    new WebDriverManager.DriverManager().SetUpDriver(new InternetExplorerConfig());
                    this.driver = new ChromeDriver();
                    break;
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}