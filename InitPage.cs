using OpenQA.Selenium;

namespace Page
{
    public class InitPage : BasePage
    {

        public InitPage(IWebDriver driver) : base(driver)
        {

        }

        private By ButLog1Id = By.Id("passp:sign-in");

        private By LogTextIDId = By.Id("passp-field-login");

        private By LogTextPasswordXPas = By.XPath("//input[@name='passwd']");

        private By ButMenu1XPas = By.XPath("//img[@class='user-pic__image']");

        private By ButMenu2XPath = By.XPath("//*[contains(@class, 'action_mail') and not(contains(@class, '-compose'))]");

        private By ButMessage1Name = By.ClassName("js-main-action-compose");

        private By recipientXPas = By.XPath("//div[@class='composeYabbles']");

        private By textXPas = By.XPath("//input[@name='subject']");

        private By ButMessage2Name = By.ClassName("ComposeSendButton_desktop");

        private By ButGetMessageXPath = By.XPath("//span[@title='TEST']");

        private By UnreadTrueName = By.ClassName("state_toRead");

        private By TextMessageName = By.ClassName("qa-MessageViewer-Title");

        private By ButLog = By.XPath("//a[@data-src='/login/']");

        private By Butnext = By.XPath("//input[@value='Войти']");
        
        private By LogText = By.Name("login");

        private By ErrMes =(By.XPath("//em[@data-name='login']"));

        private By ErrMes1 = By.ClassName("wa-error-msg");
        
        private By LogPassw = By.Name("password");


        public IWebElement ClicBut1 => driver.FindElement(ButLog);

        public IWebElement ClicBut2 => driver.FindElement(Butnext);
        
        public IWebElement ErrorMessage => driver.FindElement(ErrMes); 
        
        public IWebElement ErrorMess => driver.FindElement(ErrMes1);
        
        public IWebElement Logtxt => driver.FindElement(LogText);
        
        public IWebElement Logpwrd => driver.FindElement(LogPassw);

        public IWebElement ButLog1 => driver.FindElement(ButLog1Id);

        public IWebElement LogTextID => driver.FindElement(LogTextIDId);

        public IWebElement LogTextPassword => driver.FindElement(LogTextPasswordXPas);

        public IWebElement ButLog2 => driver.FindElement(ButLog1Id);

        public IWebElement ButMenu1 => driver.FindElement(ButMenu1XPas);

        public IWebElement ButMenu2 => driver.FindElement(ButMenu2XPath);

        public IWebElement ButMessage1 => driver.FindElement(ButMessage1Name);

        public IWebElement recipient => driver.FindElement(recipientXPas);

        public IWebElement text => driver.FindElement(textXPas);

        public IWebElement ButMessage2 => driver.FindElement(ButMessage2Name);

        public IWebElement ButGetMessage => driver.FindElement(ButGetMessageXPath);

        public IWebElement UnreadTrue => driver.FindElement(UnreadTrueName);

        public IWebElement TextMessage => driver.FindElement(TextMessageName);
     
    }
}  