using OpenQA.Selenium;


namespace SendEmail.Pages;

internal class LoginPage:BasePage
{
    string mailUser1 = "PervajaAvrora@gmail.com";
    string passwrdUser1 = "999avrora!";

    string mailUser2 = "VtorajaAvrora@gmail.com";
    string passwrdUser2 = "888avrora!";

    IWebElement _emailInput;

    public LoginPage(IWebDriver driver):base(driver)
    {
        _driver = driver;
        Initialize();
    }

    public void Initialize()
    {
        try
        {
            _emailInput = FindGoogleElement("//input[@type='email']");
        }
        catch
        {
            IWebElement chooseAccount = FindGoogleElement("//div[@id='initialView']");
            ClickElement(chooseAccount);
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
            IWebElement nextButton1 = FindGoogleElement("//div[@id='identifierNext']");
            ClickElement(nextButton1);
            IWebElement passwordInput1 = FindGoogleElement("//input[@type='password']");

            passwordInput1.SendKeys(passwrdUser1);
            IWebElement signInButton1 = FindGoogleElement("//div[@id='passwordNext']");
            ClickElement(signInButton1);
            return new MailPage(_driver);
        }
        _emailInput.SendKeys(mailUser2);

        IWebElement nextButton2 = FindGoogleElement("//div[@id='identifierNext']");
        ClickElement(nextButton2);

        IWebElement passwordInput2 = FindGoogleElement("//input[@type='password']");
        passwordInput2.SendKeys(passwrdUser2);

        IWebElement signInButton2 = FindGoogleElement("//div[@id='passwordNext']");
        ClickElement(signInButton2);
        return new MailPage(_driver);

    }

}
