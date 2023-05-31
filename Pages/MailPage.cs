using OpenQA.Selenium;


namespace SendEmail.Pages
{
    internal class MailPage:BasePage
    {
        IWebElement _writeLetterButton;
        readonly string address = "vtorajaavrora@gmail.com";

        const string WRITE_LETTER_BUTTON_XPATH = "//div[@class='T-I T-I-KE L3']";
        const string MAIL_TO_INPUT_XPATH = "//input[@aria-haspopup='listbox']";
        const string SUBJECT_INPUT_XPATH = "//input[@name='subjectbox']";
        const string MESSAGE_INPUT_XPATH = "//div[@role='textbox']";
        const string SEND_LETTER_BUTTON_XPATH = "//tr[@class='btC']/child::td[1]";
        const string LOGO_BUTTON_XPATH = "//a[@aria-label and @role='button']/child::img";
        const string IFRAME_XPATH = "//iframe[@name='account']";
        const string LOGOUT_BUTTON_XPATH = "//a[contains(@href,'Logout')]";
        const string LETTER_XPATH = "//tr[@role='row']";
        const string REPLAY_BUTTON_XPATH = "//span[contains(text(),'Reply') and @role='link']";
        const string REPLAY_MESSAGE_INPUT_XPATH = "//div[@aria-label='Message Body']";
        const string SEND_REPLAY_MESSAGE_BUTTON_XPATH = "//div[contains(text(),'Send') and @role='button']";




        public MailPage(IWebDriver driver) : base(driver)
        {
            Initialize();
        }

        public void Initialize()
        {
            _writeLetterButton = FindGoogleElement(WRITE_LETTER_BUTTON_XPATH);
        }

        public void Uninitialize()
        {
            _driver.Close();
        }

        public void SendLetter()
        {
            ClickElement(_writeLetterButton);

            IWebElement mailToInput = FindGoogleElement(MAIL_TO_INPUT_XPATH);
            mailToInput.SendKeys(address);

            IWebElement mailSubjectInput = FindGoogleElement(SUBJECT_INPUT_XPATH);
            mailSubjectInput.SendKeys("new");

            IWebElement mailTextInput = FindGoogleElement(MESSAGE_INPUT_XPATH);
            mailTextInput.SendKeys("Hi, Avrora!");

            IWebElement sendButton = FindGoogleElement(SEND_LETTER_BUTTON_XPATH);
            ClickElement(sendButton);
        }
        public IndexPage Logout()
        {
            IWebElement logoButton = FindGoogleElement(LOGO_BUTTON_XPATH);
            ClickElement(logoButton);

            IWebElement iframe = FindGoogleElement(IFRAME_XPATH);
            _driver.SwitchTo().Frame(iframe);

            IWebElement logoutButton = FindGoogleElement(LOGOUT_BUTTON_XPATH);
            ClickElement(logoutButton);
           
            IAlert alert = _driver.SwitchTo().Alert();
            alert.Accept();
            return new IndexPage(_driver);
        }
        public bool CheckLetter()
        {
            try
            {
                FindGoogleElement("//span[contains(text(),'new')]");
                FindGoogleElement("//span[contains(text(),'Hi, Avrora!')]");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void ReplyLetter()
        {
            IWebElement letter = FindGoogleElement(LETTER_XPATH);
            ClickElement(letter);

            IWebElement replyButton = FindGoogleElement(REPLAY_BUTTON_XPATH);
            ClickElement(replyButton);

            IWebElement message = FindGoogleElement(REPLAY_MESSAGE_INPUT_XPATH);
            message.SendKeys("Thanks");

            IWebElement sendButton = FindGoogleElement(SEND_REPLAY_MESSAGE_BUTTON_XPATH);
            ClickElement(sendButton);
        }

    }
}
