using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail.Pages
{
    internal class MailPage:BasePage
    {
        IWebElement _writeLetterButton;
        IWebElement _incomingLetterButton;
        List<IWebElement> _actionButtons = new List<IWebElement>();


        const string WRITE_LETTER_BUTTON_XPATH = "//div[@class='T-I T-I-KE L3']";
        const string INCOMING_LETTER_BUTTON_XPATH = "//div[@class='aim ain']";
        public MailPage(IWebDriver driver) : base(driver)
        {

            Initialize();
        }

        public void Initialize()
        {
            _writeLetterButton = FindGoogleElement(WRITE_LETTER_BUTTON_XPATH);
            _incomingLetterButton = FindGoogleElement(INCOMING_LETTER_BUTTON_XPATH);
        }
        public void Uninitialize()
        {
            _driver.Close();
        }

        public void SendLetter()
        {
            ClickElement(_writeLetterButton);

            IWebElement mailToInput = FindGoogleElement("//input[@aria-haspopup='listbox']");

            mailToInput.SendKeys("vtorajaavrora@gmail.com");

            IWebElement mailSubjectInput = FindGoogleElement("//input[@name='subjectbox']");
            mailSubjectInput.SendKeys("new");

            IWebElement mailTextInput = FindGoogleElement("//div[@role='textbox']");
            mailTextInput.SendKeys("Hi, Avrora!");

            IWebElement sendButton = FindGoogleElement("//tr[@class='btC']/child::td[1]");
            ClickElement(sendButton);
        }
        public IndexPage Logout()
        {
            IWebElement logoButton = FindGoogleElement("//a[@aria-label and @role='button']/child::img");
            ClickElement(logoButton);

            IWebElement iframe = FindGoogleElement("//iframe[@name='account']");
            _driver.SwitchTo().Frame(iframe);


            IWebElement logoutButton = FindGoogleElement("//a[contains(@href,'Logout')]");
            ClickElement(logoutButton);
           
            IAlert alert = _driver.SwitchTo().Alert();
            alert.Accept();
            return new IndexPage(_driver);
        }
        public void ReadLetter()
        {
            //div[@data-tooltip="Inbox"]
        }

    }
}
