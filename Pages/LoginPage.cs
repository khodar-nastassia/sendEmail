using OpenQA.Selenium;

namespace SendEmail.Pages;

internal class LoginPage:BasePage
{
    readonly string mailUser1 = "PervajaAvrora@gmail.com";
    readonly string passwrdUser1 = "999avrora!";

    readonly string mailUser2 = "VtorajaAvrora@gmail.com";
    readonly string passwrdUser2 = "888avrora!";

    IWebElement _emailInput;

    const string MAIL_INPUT_XPATH = "//input[@type='email']";
    const string CHOOSE_ACCOUNT_XPATH = "//ul//li[2]";
    const string NEXT_BUTTON_XPATH = "//div[@id='identifierNext']";
    const string PASSWORD_INPUT_XPATH = "//input[@name='Passwd']";
    const string PASSWORD2_INPUT_XPATH = "//input[@name='password']";
    const string SIGNIN_BUTTON_XPATH = "//div[@id='passwordNext']";

    public LoginPage(IWebDriver driver):base(driver)
    {
        _driver = driver;
        Initialize();
    }

    public void Initialize()
    {
        try
        {
            _emailInput = FindGoogleElement(MAIL_INPUT_XPATH);
        }
        catch
        {
            IWebElement chooseAccount = FindGoogleElement(CHOOSE_ACCOUNT_XPATH);
            ClickElement(chooseAccount);
            _emailInput = FindGoogleElement(MAIL_INPUT_XPATH);
        }
    }
 
    public void Uninitialize()
    {
        _driver.Close();
    }

    public MailPage InputUserData(int user)
    {
        if (user == 1)
        {
            _emailInput.SendKeys(mailUser1);
            IWebElement nextButton1 = FindGoogleElement(NEXT_BUTTON_XPATH);
            ClickElement(nextButton1);
            IWebElement passwordInput1 = FindGoogleElement(PASSWORD_INPUT_XPATH);
            Thread.Sleep(1000);

            passwordInput1.SendKeys(passwrdUser1);
            IWebElement signInButton1 = FindGoogleElement(SIGNIN_BUTTON_XPATH);
            ClickElement(signInButton1);
            return new MailPage(_driver);
        }
        Thread.Sleep(1000);
        _emailInput.SendKeys(mailUser2);

        IWebElement nextButton2 = FindGoogleElement(NEXT_BUTTON_XPATH);
        ClickElement(nextButton2);

        IWebElement passwordInput2 = FindGoogleElement(PASSWORD2_INPUT_XPATH);
        Thread.Sleep(2000);
        passwordInput2.SendKeys(passwrdUser2);

        IWebElement signInButton2 = FindGoogleElement(SIGNIN_BUTTON_XPATH);
        ClickElement(signInButton2);
        return new MailPage(_driver);

    }

}
