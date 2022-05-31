using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.IO;
using WebDriverManager;
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
                    var config = new ChromeConfig();
                    var path = Path.GetDirectoryName(new DriverManager().SetUpDriver(config, config.GetMatchingBrowserVersion()));
                    this.driver = new ChromeDriver(path);
                    break;
                case "FIREFOX":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    this.driver = new FirefoxDriver();
                    break;
                case "IE":
                    new DriverManager().SetUpDriver(new InternetExplorerConfig());
                    this.driver = new InternetExplorerDriver();
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