using OpenQA.Selenium;

namespace Page
{
    public class BasePage
    {
        protected static IWebDriver driver;
        public BasePage(IWebDriver Wdriver)
        {
            driver = Wdriver;
        }
    }
}
